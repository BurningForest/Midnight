using Midnight.Actions;
using Midnight.ChiefOperations;
using Midnight.Core;
using Midnight.Triggers;

namespace Midnight
{
    public class Engine
    {

        public class ClonedEngine : Engine
        {
        }

        public static void Main(string[] args) { }

        public readonly Emitter.EventEmitter Emitter;
        public readonly ActionManager.Manager Actions;
        public readonly Battlefield.Field Field;
        public readonly Chief[] Chiefs;
        public readonly Turn Turn;
        public readonly Lantern Lantern;
        public readonly Cache Cache;
        public readonly TriggersContainer Triggers;

        public Final Final { get; private set; }

        public Engine()
        {
            Emitter = new Emitter.EventEmitter();
            Actions = new ActionManager.Manager(this);

            Cache = new Cache();
            Triggers = new TriggersContainer(this);

            Field = new Battlefield.Field().SetSize(5, 3);

            Chiefs = new Chief[]{
                new Chief(0).SetEngine(this),
                new Chief(1).SetEngine(this),
            };

            Turn = new Turn(this);
            Lantern = new Lantern(this);
        }

        public ClonedEngine Clone()
        {
            return new Copier(this).GetClone();
        }

        internal void Finish(Final final)
        {
            if (Final == null)
            {
                Final = final;
            }
        }

    }
}
