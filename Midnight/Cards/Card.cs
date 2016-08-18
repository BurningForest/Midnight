using Midnight.Cards.Props;
using Midnight.ChiefOperations;
using Sun.CardProtos;
using Sun.CardProtos.Enums;

namespace Midnight.Cards
{
	public abstract class Card
	{
        private const int MaxPropValue = 99;

        private Chief _chief;
		private CardLocation _location;

        public int Id { get; private set; }
        public Abilities Abilities { get; protected set; }
		public ModifierContainer Modifiers { get; protected set; }

		public virtual CardLocation GetLocation ()
		{
			if (_location == null)
            {
				CreateLocation();
			}
			return _location;
		}

		public virtual void CreateLocation ()
		{
			_location = new CardLocation(this);
		}

		public abstract Proto GetProto ();

		public bool IsDead ()
		{
			return GetLocation().IsGraveyard();
		}

		public void SetId (int id)
		{
			Id = id;
		}

		public void SetChief (Chief chief)
		{
			_chief = chief;
		}

		public Chief GetChief ()
		{
			return _chief;
		}

		public void Reset ()
		{
			Abilities = new Abilities(this);
			Modifiers = new ModifierContainer();
		}

		public virtual void InitAbilities ()
		{
		}

		public bool IsControlledBy (Chief chief)
		{
			return _chief == chief;
		}

		public bool IsEnemyOf (Card target)
		{
			return !target.IsControlledBy(_chief);
		}

		public bool Is (Country country)
		{
			return GetProto().Country == country;
		}

		public bool Is (Subtype subtype)
		{
			return GetProto().Subtype == subtype;
		}

		public bool Is (Type type)
		{
			return GetProto().Type == type;
		}

		public void Modify (Modifier modifier)
		{
			Modifiers.Add(modifier);
		}


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
			return Limit(property.GetProtoValue(GetProto()) + Modifiers.GetPropertySum(property), MaxPropValue);
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
			return Modifiers.GetPropertySum(Property.damage);
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