using System.Linq;
using System.Collections.Generic;
using Midnight.Cards;
using Midnight.Battlefield;
using Midnight.Cards.Types;

namespace Midnight.ChiefOperations
{
	public class Chief
	{
		private Engine engine;

		public readonly int index;
		public readonly Io io;

		public readonly CardsContainer cards;

		private int resources = 0;

		public Chief (int index)
		{
			this.index = index;
			io = new Io(this);
			cards = new CardsContainer(this);
		}

		public Emulated GetEmulated ()
		{
			return new Emulated(this);
		}

		public Chief SetEngine (Engine engine)
		{
			this.engine = engine;
			io.SetEngine(engine);
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
			var HQs = cards.GetAliveHqs();

			if (HQs.Count == 0) {
				return engine.field.GetCellsByColumn(GetStartCell().X);
			} else if (HQs.Count == 1) {
				return HQs[0].GetFootholdCells();
			} else {
				return CompileFootholdCells(HQs);
			}
		}

		private List<Cell> CompileFootholdCells (List<Hq> HQs)
		{
			IEnumerable<Cell> cells = new List<Cell>();

			foreach (Hq HQ in HQs) {
				cells = cells.Union(HQ.GetFootholdCells());
			}

			return cells.ToList();
		}

		public bool IsTurnOwner ()
		{

			return engine.turn.GetOwner() == this;
		}
	}
}
