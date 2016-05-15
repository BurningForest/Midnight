using Midnight.Engine.Cards.Enums;
using Midnight.Engine.Cards.Props;
using Midnight.Engine.ChiefOperations;

namespace Midnight.Engine.Cards
{
	public abstract class Card
	{
		//todo: spotted

		private int id;
		private Chief chief;
		public Abilities abilities { get; private set; }

		private readonly ModifierContainer modifiers = new ModifierContainer();
		private CardLocation location;
		
		public virtual CardLocation GetLocation ()
		{
			if (location == null) {
				location = new CardLocation(this);
			}

			return location;
		}

		public abstract Proto GetProto ();

		public bool IsDead ()
		{
			return GetLocation().IsGraveyard();
		}

		public void SetChief (Chief chief)
		{
			this.chief = chief;
		}

		public Chief GetChief ()
		{
			return chief;
		}

		public virtual void InitAbilities ()
		{
			abilities = new Abilities(this);
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
	}
}