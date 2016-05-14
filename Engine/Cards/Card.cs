using Midnight.Engine.Abilities;
using Midnight.Engine.Cards.Enums;
using Midnight.Engine.Cards.Props;
using Midnight.Engine.ChiefOperations;
using System.Collections.Generic;

namespace Midnight.Engine.Cards
{
	public abstract class Card
	{
		//todo: spotted

		private Location location = null;
		private int id;
		private Chief chief;
		private List<CardAbility> abilities;
		private ModifierContainer modifiers;

		public abstract Proto GetProto ();

		public Location GetLocation ()
		{
			return location;
		}

		public bool IsAt (Location location)
		{
			return this.location == location;
		}

		public virtual void ToLocation (Location target)
		{
			if (location == target) {
				return;
			}

			location = target;
		}

		public void ToReserve () { ToLocation(Location.reserve); }
		public void ToGraveyard () { ToLocation(Location.graveyard); }
		public void ToDeck () { ToLocation(Location.deck); }

		public bool IsAtBattlefield () { return IsAt(Location.battlefield); }
		public bool IsAtSupport () { return IsAt(Location.support); }
		public bool IsAtReserve () { return IsAt(Location.reserve); }
		public bool IsAtGraveyard () { return IsAt(Location.graveyard); }
		public bool IsAtDeck () { return IsAt(Location.deck); }
		public bool IsNowhere () { return IsAt(null); }

		public virtual bool IsActiveHq () { return false; }
		public virtual bool IsActiveVehicle () { return false; }
		public virtual bool IsActivePlatoon () { return false; }

		public TAbility GetActiveAbility<TAbility> ()
			where TAbility : CardAbility
		{
			foreach (var ability in abilities) {
				if (ability is TAbility) {
					return (TAbility)ability;
				}
			}

			return null;
		}

		public bool HasActiveAbility<TAbility> ()
			where TAbility : CardAbility
		{
			return GetActiveAbility<TAbility>() != null;
		}

		public bool IsInForefront ()
		{
			return IsAtBattlefield() || IsAtSupport();
		}

		public bool IsDead ()
		{
			return IsAtGraveyard();
		}

		public void SetChief (Chief chief)
		{
			this.chief = chief;
		}

		public Chief GetChief ()
		{
			return chief;
		}

		public abstract CardAbility[] CreateAbilities ();

		public void AddAbility (CardAbility ability)
		{
			ability.SetOwner(this);
			abilities.Add(ability);
		}

		public void InitAbilities ()
		{
			abilities = new List<CardAbility>();

			foreach (var ability in CreateAbilities()) {
				AddAbility(ability);
			}
		}

		public bool IsControlledBy (Chief chief)
		{
			return this.chief == chief;
		}

		public bool IsEnemyOf (Card target)
		{
			return !target.IsControlledBy(chief);
		}

		public bool Is (Country country)
		{
			return GetProto().country == country;
		}

		public bool Is (Subtype subtype)
		{
			return GetProto().subtype == subtype;
		}

		public bool Is (Type type)
		{
			return GetProto().type == type;
		}

		public void Modify (Modifier modifier)
		{
			modifiers.Add(modifier);
		}

		public int GetPropertyValue (Property property)
		{
			return property.GetProtoValue(GetProto()) + modifiers.GetPropertySum(property);
		}

		public int GetCost ()
		{
			return GetPropertyValue(Property.cost);
		}

		public int GetIncrease ()
		{
			return GetPropertyValue(Property.increase);
		}

		public int GetToughness ()
		{
			return GetPropertyValue(Property.toughness);
		}

		public int GetPower ()
		{
			return GetPropertyValue(Property.power);
		}

		public int GetDefense ()
		{
			return GetPropertyValue(Property.defense);
		}
	}
}