using Midnight.Actions;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.ChiefOperations;
using System;
using System.Collections.Generic;

namespace Midnight.Core
{
	public class Manage
	{
		public readonly Engine engine;

		public Manage (Engine engine)
		{
			this.engine = engine;
		}

		public StartGame StartGame ()
		{
			return StartGame(engine.chiefs[0]);
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

		public void Heal (int v, Card target, Card source)
		{
			throw new NotImplementedException();
		}

		public DealDamage Damage (int value, FieldCard target, FieldCard source)
		{
			return Launch(new DealDamage(value, source, target));
		}

		public Death Kill (Card target)
		{
			return Launch(new Death.Forced(target));
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
			where TAction : ActionManager.GameAction
		{
			engine.actions.Launch(action);
			return action;
		}
	}
}
