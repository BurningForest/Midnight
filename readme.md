### Creating base battle
```cs
var engine = new Midnight.Engine();
var manage = new Midnight.Core.Manage(engine);

// initialize triggers (game rules)
engine.triggers.Register<CardAutoDraw>(); // draw card on each turn
engine.triggers.Register<ReserveCleanUp>(); // destroy more than 6 cards on turn begin
engine.triggers.Register<FinalHqDeath>(); // finilize game if one of HQs is destroyed
engine.triggers.Register<FinalDeckOut>(); // finilize game if user cant draw card
engine.triggers.Register<TurnAddResources>(); // recount resources on turn begin

// initialize cards of first chief using `cards.factory`
engine.chiefs[0].cards.factory.CreateDefaultHq<TrainingCamp>();
engine.chiefs[0].cards.factory.Create<T1Light>();
// ...
engine.chiefs[0].cards.factory.Create<A7v>();

// another way is using prototypes
engine.chiefs[1].cards.factory.CreateDefaultHq(TrainingBase.proto);
engine.chiefs[1].cards.factory.Create(T1Light.proto);
// ...
engine.chiefs[1].cards.factory.Create(A7v.proto);

// Draw random cards to reserves
manage.Draw(engine.chiefs[0], 6);
manage.Draw(engine.chiefs[1], 6);

// start game with random user
manage.StartGame(engine.chiefs[random.next(engine.chiefs.Length)]);
```

### Listen and serialize game events
```cs
class MyListener :
	IListener<After<GameEvent>>,
	IListener<After<Final>>
{

	public MyListener (Midnight.Engine engine) {
		engine.emitter.Subscribe(this);
	}

	public void On (After<GameEvent> ev) {
		if (ev.action.IsTop()) {
			// any top actions, that does not contain parents
		}
	}
	
	public void On (After<Final> ev) {
		// ev.action here is Actions.Final
		// you can subscribe on specific events
	}
}
```

### Receive possible options for chief WaitInput
```cs
List<CardOption> options = engine.chiefs[0].io.options.GetAvailable();

options[0].cardId;

options[0].deploys;
options[0].moves;
options[0].attacks;
options[0].orders;
```

### Control chief actions

We have such interface in game:
```cs
public interface IIo
{
	Status Attack (Io.Target command);

	Status Deploy (Io.SingleCard command);
	Status Deploy (Io.Position command);

	Status Move   (Io.Position command);

	Status Order  (Io.Target command);
	Status Order  (Io.SingleCard command);

	Status EndTurn ();
}
```

You can use it with such way:
```cs
IIo io = engine.chiefs[0].io;

Status status = io.Attack(new Io.Target(){ sourceId = 3, targetId = 6 });

if (status == Status.Success) {
	return true;
} else {
	WriteError(status); // status contains error if user give you wrong data
	return false;
}
```

### Cast string id to Midnight card
Unfortunately, you can't just create card of specific id, that's why you need to create your own mapping:

```cs
Proto GetProto(string protoId) {
	switch(protoId) {
		case 'gv_a7v':
			return Midnight.Instances.Germany.Vehicle.A7v.proto;
		case 'gv_panzerjagerI':
			return Midnight.Instances.Germany.Vehicle.Jag1.proto;
		case 'gv_leichttraktor':
			return Midnight.Instances.Germany.Vehicle.LTraktor.proto;
		case 'gv_t21':
			return Midnight.Instances.Germany.Vehicle.T21.proto;
		// ... and so on
	}
}
```

### Example of action cycle:
Such structure can be logged using `Midnight.Utils.Logger`

```
StartGame(0)
| BeginTurn(0)
Position(TankMedium(0, 1), {1:1})
Position(TankHeavy(1, 2), {2:1})
| Spotted()
| Spotted()
Fight(TankMedium(0, 1), TankHeavy(1, 2))
| FightRound():FightRoundIsEmpty
| FightRound()
| | Attack(TankMedium(0, 1), TankHeavy(1, 2))
| | | NonLethal(TankHeavy(1, 2), 2)
| | | | AddModifier(TankHeavy(1, 2), damage, 2)
| | CounterAttack(TankHeavy(1, 2), TankMedium(0, 1))
| | | NonLethal(TankMedium(0, 1), 3)
| | | | AddModifier(TankMedium(0, 1), damage, 3)
| | Death(TankHeavy(1, 2)):CardHasLives
| | Death(TankMedium(0, 1)):CardHasLives

```