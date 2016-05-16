using System;
using System.Linq;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Battlefield;
using Midnight.Cards.Types;
using Midnight.Cards.Enums;

namespace Midnight.ChiefOperations
{
	public class Chief
	{
		private Engine engine;

		public readonly int index;
		
		public readonly CardsContainer cards;

		private int resources = 0;

		public Chief (int index)
		{
			this.index = index;
			cards = new CardsContainer(this);
		}

		public Chief SetEngine (Engine engine)
		{
			this.engine = engine;
			return this;
		}

		public Engine GetEngine ()
		{
			return engine;
		}

		public Chief GetOpponent ()
		{
			return engine.chiefs[1] == this
				? engine.chiefs[0]
				: engine.chiefs[1];
		}

		public void PayResources (int value)
		{
			if (value > resources) {
				resources = 0;
			} else {
				resources -= value;
			}
		}

		public void GiveResources (int value)
		{
			resources += value;
		}

		public int GetResources ()
		{
			return resources;
		}

		public void SetResources (int value)
		{
			resources = value;
		}

		public int GetTotalIncrease ()
		{
			int increase = 0;

			foreach (Card card in cards.GetAll()) {
				if (card.GetLocation().IsForefront()) {
					increase += card.GetIncrease();
				}
			}

			return increase;
		}

		public Cell GetStartCell ()
		{
			return engine.field.GetCornerCell(index == 1);
		}

		public List<Cell> GetFootholdCells ()
		{
			var hqs = cards.GetAliveHqs();

			if (hqs.Count == 0) {
				return engine.field.GetCellsByColumn(GetStartCell().x);
			} else if (hqs.Count == 1) {
				return hqs[0].GetFootholdCells();
			} else {
				return CompileFootholdCells(hqs);
			}
		}

		private List<Cell> CompileFootholdCells (List<Hq> hqs)
		{
			var cells = new List<Cell>();

			foreach (Hq hq in hqs) {
				cells.AddRange(hq.GetFootholdCells());
			}

			return cells;
		}

		public bool IsTurnOwner ()
		{

			return engine.turn.GetOwner() == this;
		}
	}
}
