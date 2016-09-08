using System;
using System.Timers;
using Midnight.ActionManager.Events;
using Midnight.Actions;
using Midnight.Emitter;

namespace Midnight.ChiefOperations
{
	public class GameTimer : IListener<After<BeginTurn>>, IListener<After<EndTurn>>, IListener<After<Final>>
	{
		private readonly Timer _timer;
		private readonly TimeLeft _timeLeft;
		private readonly Chief _chief;
		private Engine _engine;

		public GameTimer(Chief chief)
		{
			_chief = chief;

			_timer = new Timer(1000); //miliseconds
			_timer.Elapsed += Tick;

			_timeLeft = new TimeLeft
			{
				BattleTimeLeft = 900, //seconds
				TurnTimeLeft = 120 //seconds
			};
		}

		public void Tick(object sender, EventArgs e)
		{
			_timeLeft.TurnTimeLeft--;
			_timeLeft.BattleTimeLeft--;

			if (_timeLeft.BattleTimeLeft == 0)
			{
				_timer.Stop();
				_engine.Actions.Delay(new Final(_chief.GetOpponent(), Final.Trigger.GlobalTimerExpired)); //or launch?
				return;
			}
			if (_timeLeft.TurnTimeLeft == 0)
			{
				_chief.Io.EndTurn();
			}
		}
		public TimeLeft GetTimeLeft()
		{
			return _timeLeft;
		}
		public void SetEngine(Engine engine)
		{
			_engine = engine;
			_engine.Emitter.Subscribe(this);
		}
		public void On(After<BeginTurn> ev)
		{
			if (_chief.IsTurnOwner())
			{
				_timeLeft.TurnTimeLeft = _timeLeft.BattleTimeLeft < 120 ? _timeLeft.BattleTimeLeft : 120;
				_timer.Start();
			}
		}
		public void On(After<EndTurn> ev)
		{
			if (_chief.IsTurnOwner())
			{
				_timer.Stop();
			}
		}
		public void On(After<Final> ev)
		{
			_timer.Stop();
			_timer.Dispose();
		}
	}

	public class TimeLeft
	{
		public int BattleTimeLeft { get; set; }
		public int TurnTimeLeft { get; set; }
	}
}
