using Midnight.Cards.Enums;
using Midnight.Cards.Props;
using Midnight.ChiefOperations;
using Sun.CardProtos.Enums;

namespace Midnight.Cards
{
	public abstract class Card
	{
		public int id { get; private set; }
		private CardLocation location;

		public Abilities abilities { get; protected set; }
		public ModifierContainer modifiers { get; protected set; }

		private Chief chief;

		public virtual CardLocation GetLocation ()
		{
			if (location == null) {
				CreateLocation();
			}
			return location;
		}

		public virtual void CreateLocation ()
		{
			location = new CardLocation(this);
		}

		public abstract Proto GetProto ();

		public bool IsDead ()
		{
			return GetLocation().IsGraveyard();
		}

		public void SetId (int id)
		{
			this.id = id;
		}

		public void SetChief (Chief chief)
		{
			this.chief = chief;
		}

		public Chief GetChief ()
		{
			return chief;
		}

		public void Reset ()
		{
			abilities = new Abilities(this);
			modifiers = new ModifierContainer();
		}

		public virtual void InitAbilities ()
		{
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

		private const int MAX_PROP_VALUE = 99;

		public static int Limit (int num, int max)
		{
			return num > max ? max : Limit(num);
		}

		public static int Limit (int num)
		{
			return num < 0 ? 0 : num;
		}

		public int GetPropertyValue<TProperty> (TProperty property)
			where TProperty : Property
		{
			return Limit(property.GetProtoValue(GetProto()) + modifiers.GetPropertySum(property), MAX_PROP_VALUE);
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

		public int GetDamage ()
		{
			return modifiers.GetPropertySum(Property.damage);
		}

		public int GetLives ()
		{
			return Limit(GetToughness() - GetDamage());
		}

		public virtual bool IsActive ()
		{
			return false;
		}

		public bool IsActive<Type> ()
		{
			return this is Type && IsActive();
		}

		public virtual Card CloneFor (Chief chief)
		{
			var clone = (Card) MemberwiseClone();
			clone.CreateLocation();
			clone.SetChief(chief);
			clone.GetLocation().CloneFrom(GetLocation());
			clone.Reset(); // modifiers and abilities should be cloned when all cards are created
			return clone;
		}
	}
}