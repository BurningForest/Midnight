using Midnight.Engine.Actions;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards;
using Midnight.Engine.ChiefOperations;
using System;
using System.Collections.Generic;

namespace Midnight.Engine.Core
{
	public class Manage
	{
		public readonly ActionManager.Manager manager;

		public Manage (ActionManager.Manager manager)
		{
			this.manager = manager;
		}

		public StartGame StartGame (Chief chief)
		{
			return Launch(new StartGame(chief));
		}

		public EndTurn EndTurn (Chief chief)
		{
			return Launch(new EndTurn(chief));
		}

		public void Fight (Card card1, Card card2)
		{
			throw new NotImplementedException();
		}

		public void Position (Card card, Cell cell)
		{
			throw new NotImplementedException();
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

		public void Damage (int v, Card target, Card source)
		{
			throw new NotImplementedException();
		}

		public void Order (Order order, Card card)
		{
			throw new NotImplementedException();
		}

		private TAction Launch<TAction> (TAction action)
			where TAction : ActionManager.Action
		{
			manager.Launch(action);
			return action;
		}
	}
}
