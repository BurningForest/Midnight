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

		public void DrawList (List<Card> cards)
		{
			throw new NotImplementedException();
		}

		public void Draw (int v, Chief chief)
		{
			throw new NotImplementedException();
		}

		public void Heal (int v, Card target, Card source)
		{
			throw new NotImplementedException();
		}

		public DealDamage Damage (int value, FieldCard target, FieldCard source)
		{
			return Launch(new DealDamage(value, source, target));
		}

		public void Order (Order order, Card card)
		{
			throw new NotImplementedException();
		}

		private TAction Launch<TAction> (TAction action)
			where TAction : ActionManager.GameAction
		{
			engine.actions.Launch(action);
			return action;
		}
	}
}
