using Midnight.Engine.Abilities;
using Midnight.Engine.Battlefield;
using Midnight.Engine.Cards.Prototype;
using Midnight.Engine.ChiefOperations;

namespace Midnight.Engine.Cards
{
	public abstract class Card
	{
		//todo: spotted

		private Location location = null;
		private int id;
		private Chief chief;

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

		public void ToReserve   () { ToLocation(Location.reserve); } 
		public void ToGraveyard () { ToLocation(Location.graveyard); } 
		public void ToDeck      () { ToLocation(Location.deck); }

		public bool IsAtBattlefield () { return IsAt(Location.battlefield); }
		public bool IsAtSupport     () { return IsAt(Location.support); }
		public bool IsAtReserve     () { return IsAt(Location.reserve); }
		public bool IsAtGraveyard   () { return IsAt(Location.graveyard); }
		public bool IsAtDeck        () { return IsAt(Location.deck); }
		public bool IsNowhere       () { return IsAt(null); }

		public bool IsActiveHq () { return IsHq() && IsAtBattlefield(); }
		public bool IsActiveVehicle () { return IsVehicle() && IsAtBattlefield(); }
		public bool IsActivePlatoon () { return IsPlatoon() && IsAtSupport(); }

		public TAbility GetActiveAbility<TAbility> ()
			where TAbility : CardAbility
		{
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

		public virtual bool IsHq      () { return false; }
		public virtual bool IsPlatoon () { return false; }
		public virtual bool IsOrder   () { return false; }
		public virtual bool IsAttack  () { return false; }
		public virtual bool IsDefense () { return false; }
		public virtual bool IsVehicle () { return false; }
		public virtual bool IsLight   () { return false; }
		public virtual bool IsMedium  () { return false; }
		public virtual bool IsHeavy   () { return false; }
		public virtual bool IsSpatg   () { return false; }
		public virtual bool IsSpg     () { return false; }

		public int GetCost      () { return GetProto().cost; }
		public int GetIncrease  () { return GetProto().increase; }
		public int GetToughness () { return GetProto().toughness; }
		public int GetPower     () { return GetProto().power; }
		public int GetDefense   () { return GetProto().defense; }
	}
}