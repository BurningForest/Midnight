using System.Collections.Generic;
using System.Linq;
using Midnight.Battlefield;
using Midnight.Cards.Types;

namespace Midnight.ChiefOperations
{
    public class Chief
    {
        private Engine _engine;
        private int _resources;
        public int Index { get; }
        public Io Io { get; }
        public CardsContainer Cards { get; }

        public Chief(int index)
        {
            Index = index;
            Io = new Io(this);
            Cards = new CardsContainer(this);
        }

        public Emulated GetEmulated()
        {
            return new Emulated(this);
        }

        public Chief SetEngine(Engine engine)
        {
            _engine = engine;
            Io.SetEngine(engine);
            return this;
        }

        public Engine GetEngine()
        {
            return _engine;
        }

        public Chief GetOpponent()
        {
            return _engine.chiefs[1] == this
                ? _engine.chiefs[0]
                : _engine.chiefs[1];
        }

        public void PayResources(int value)
        {
            if (value > _resources)
            {
                _resources = 0;
            }
            else
            {
                _resources -= value;
            }
        }

        public void GiveResources(int value)
        {
            _resources += value;
        }

        public int GetResources()
        {
            return _resources;
        }

        public void SetResources(int value)
        {
            _resources = value;
        }

        public int GetTotalIncrease()
        {
            return Cards.GetAll().Where(card => card.GetLocation().IsForefront()).Sum(card => card.GetIncrease());
        }

        public Cell GetStartCell()
        {
            return _engine.field.GetCornerCell(Index == 1);
        }

        public List<Cell> GetFootholdCells()
        {
            var hQs = Cards.GetAliveHqs();

            switch (hQs.Count)
            {
                case 0:
                    return _engine.field.GetCellsByColumn(GetStartCell().X);
                case 1:
                    return hQs[0].GetFootholdCells();
            }
            return CompileFootholdCells(hQs);
        }

        private List<Cell> CompileFootholdCells(List<Hq> HQs)
        {
            IEnumerable<Cell> cells = new List<Cell>();

            cells = HQs.Aggregate(cells, (current, HQ) => current.Union(HQ.GetFootholdCells()));

            return cells.ToList();
        }

        public bool IsTurnOwner()
        {

            return _engine.turn.GetOwner() == this;
        }
    }
}
