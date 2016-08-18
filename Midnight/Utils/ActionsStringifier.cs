using Midnight.ActionManager;
using Midnight.Actions;
using Midnight.Battlefield;
using Midnight.Cards;
using Midnight.Cards.Types;
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
			if (card == null)
            {
				return "null";
			} 

			return card.GetType().Name + "(" + card.GetChief().index + ", " + card.id + ")";
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
			return Group(action.Chief.index);
		}

		public string[] GetDynamicArgs (BeginTurn action)
		{
			return Group(action.Chief.index);
		}

		public string[] GetDynamicArgs (EndTurn action)
		{
			return Group(action.Chief.index);
		}

		public string[] GetDynamicArgs (Position action)
		{
			return Group(LogCard(action.Card), LogCell(action.Cell));
		}

		public string[] GetDynamicArgs (Move action)
		{
			return Group(LogCard(action.Card), LogCell(action.Cell));
		}

		public string[] GetDynamicArgs (Step action)
		{
			return Group(LogCard(action.Card), LogCell(action.Cell));
		}

		public string[] GetDynamicArgs (Deploy action)
		{
		    var card = action.Card as FieldCard;
		    return (card != null)
				? Group(LogCard(card), LogCell(action.Cell))
				: Group(LogCard(action.Card));
		}

	    public string[] GetDynamicArgs (Fight action)
		{
			return Group(LogCard(action.Source), LogCard(action.Target));
		}

		public string[] GetDynamicArgs (Attack action)
		{
			return Group(LogCard(action.Source), LogCard(action.Target));
		}

		public string[] GetDynamicArgs (CounterAttack action)
		{
			return Group( LogCard(action.Source), LogCard(action.Target) );
		}

		public string[] GetDynamicArgs (AddModifier action)
		{
			return Group(
				LogCard(action.Modifier.GetTarget()),
				action.Modifier.GetProperty(),
				action.Modifier.GetValue()
			);
		}

		public string[] GetDynamicArgs (DealDamage action)
		{
			return Group(LogCard(action.Target), action.Value);
		}

		public string[] GetDynamicArgs (HealDamage action)
		{
			return Group(LogCard(action.Target), action.Value);
		}

		public string[] GetDynamicArgs (Death action)
		{
			return Group( LogCard(action.Card) );
		}

		public string[] GetDynamicArgs (PayResources action)
		{
			return Group( action.Chief.index, action.Value );
		}

		public string[] GetDynamicArgs (SetResources action)
		{
			return Group(action.Chief.index, action.Value);
		}

		public string[] GetDynamicArgs (Draw action)
		{
			return Group(LogCard(action.Card));
		}

		public string[] GetDynamicArgs (DrawRandom action)
		{
			return Group(action.Chief.index);
		}

		public string[] GetDynamicArgs (DrawCount action)
		{
			return Group(action.Chief.index, action.Count);
		}

		public string[] GetDynamicArgs (DrawList action)
		{
			return Group(action.Cards.Count());
		}
	}
}
