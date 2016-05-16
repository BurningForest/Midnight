using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.Core;
using System.Linq;

namespace Midnight.Utils
{
	public class ActionsStringifier
	{

		private string[] Group (params object[] args)
		{
			return args.Select(o => o.ToString()).ToArray();
		}

		public string LogCard (Card card)
		{
			return card.GetType().Name + "(" + card.GetChief().index + ")";
		}

		public string LogCell (Cell cell)
		{
			return "{" + cell.x + ":" + cell.y + "}";
		}

		public string GetName (GameAction action)
		{
			return action.GetType().Name;
		}

		public string[] GetArgs (GameAction action)
		{
			return GetDynamicArgs(action as dynamic);
		}

		public string[] GetDynamicArgs (GameAction action)
		{
			return new string[0];
		}

		public string[] GetDynamicArgs (StartGame action)
		{
			return Group(action.chief.index);
		}

		public string[] GetDynamicArgs (BeginTurn action)
		{
			return Group(action.chief.index);
		}

		public string[] GetDynamicArgs (EndTurn action)
		{
			return Group(action.chief.index);
		}

		public string[] GetDynamicArgs (Position action)
		{
			return Group(LogCard(action.card), LogCell(action.cell));
		}

		public string[] GetDynamicArgs (Move action)
		{
			return Group(LogCard(action.card), LogCell(action.cell));
		}

		public string[] GetDynamicArgs (Step action)
		{
			return Group(LogCard(action.card), LogCell(action.cell));
		}

		public string[] GetDynamicArgs (Deploy action)
		{
			return (action.card is FieldCard)
				? Group(LogCard(action.card), LogCell(action.cell))
				: Group(LogCard(action.card));
		}

		public string[] GetDynamicArgs (Fight action)
		{
			return Group(LogCard(action.source), LogCard(action.target));
		}

		public string[] GetDynamicArgs (Attack action)
		{
			return Group(LogCard(action.source), LogCard(action.target));
		}

		public string[] GetDynamicArgs (CounterAttack action)
		{
			return Group( LogCard(action.source), LogCard(action.target) );
		}

		public string[] GetDynamicArgs (AddModifier action)
		{
			return Group(
				LogCard(action.modifier.GetTarget()),
				action.modifier.GetProperty(),
				action.modifier.GetValue()
			);
		}

		public string[] GetDynamicArgs (DealDamage action)
		{
			return Group( LogCard(action.target), action.value );
		}

		public string[] GetDynamicArgs (Death action)
		{
			return Group( LogCard(action.card) );
		}

		public string[] GetDynamicArgs (PayResources action)
		{
			return Group( action.chief.index, action.value );
		}

		public string[] GetDynamicArgs (SetResources action)
		{
			return Group( action.chief.index, action.value );
		}
	}
}
