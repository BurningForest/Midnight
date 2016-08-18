using System.Collections.Generic;
using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;

namespace Midnight.Core
{
	public class Manage
	{
		public readonly Engine Engine;

		public Manage (Engine engine)
		{
			Engine = engine;
		}

		public StartGame StartGame ()
		{
			return StartGame(Engine.chiefs[0]);
		}

		public StartGame StartGame (Chief chief)
		{
			return Launch(new StartGame(chief));
		}

		public EndTurn EndTurn (Chief chief)
		{
			return Launch(new EndTurn(chief));
		}

		public Fight Fight (FieldCard source, FieldCard target)
		{
			return Launch(new Fight(source, target));
		}

		public Position Position (FieldCard card, Cell cell)
		{
			return Launch(new Position(card, cell));
		}

		public Move Move (FieldCard card, Cell cell)
		{
			return Launch(new Move(card, cell));
		}

		public Deploy Deploy (Platoon card)
		{
			return Launch(new Deploy(card, null));
		}

		public Deploy Deploy (FieldCard card, Cell cell)
		{
			return Launch(new Deploy(card, cell));
		}

		public Draw Draw (Card card)
		{
			return Launch(new Draw(card));
		}

		public DrawList Draw (IEnumerable<Card> cards)
		{
			return Launch(new DrawList(cards));
		}

		public DrawCount Draw (Chief chief, int v)
		{
			return Launch(new DrawCount(chief, v));
		}

		public DrawCount Draw (Chief chief)
		{
			return Draw(chief, 1);
		}

		public HealDamage Heal (int value, FieldCard target, Card source)
		{
			return Launch(new HealDamage(value, source, target));
		}

		public DealDamage Damage (int value, FieldCard target, Card source)
		{
			return Launch(new DealDamage(value, source, target));
		}

		public Death Kill (Card target)
		{
			return Launch(new Death.Forced(target));
		}

		public Final Surrender (Chief loser)
		{
			return Launch(new Final(loser.GetOpponent(), Final.Trigger.Surrender));
		}

		public SetResources SetResources (Chief chief, int value)
		{
			return Launch(new SetResources(chief, value));
		}

		public GiveOrder Order (Order order, FieldCard target)
		{
			return Launch(new GiveOrder(order, target));
		}

		public GiveOrder Order (Order order)
		{
			return Launch(new GiveOrder(order));
		}

		private TAction Launch<TAction> (TAction action)
			where TAction : GameAction
		{
			Engine.actions.Launch(action);
			return action;
		}
	}
}
