using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.Core;

namespace Midnight.ChiefOperations
{
	public class Io : IIo
	{
		public class Target
		{
			public int sourceId;
			public int targetId;
		}

		public class SingleCard
		{
			public int cardId;
		}

		public class Position
		{
			public int cardId;
			public int x;
			public int y;
		}

		private readonly Chief chief;
		private Engine engine;
		private Manage manage;

		public Io (Chief chief)
		{
			this.chief = chief;
		}

		private Card GetCard (int id)
		{
			return id == 0
				? null
				: engine.cache.Get(id);
		}

		public void SetEngine (Engine engine)
		{
			this.engine = engine;
			manage = new Manage(engine);
		}

		private Status ValidateCards (int sourceId, int target)
		{
			if (!IsCardExists(target)) {
				return Status.NoTargetCard;
			}

			return ValidateCard(sourceId);
		}

		private Status ValidateCard (int sourceId)
		{
			if (!IsCardExists(sourceId)) {
				return Status.NoSourceCard;
			}

			if (!IsCardOwned(sourceId)) {
				return Status.WrongCardOwner;
			}

			return Status.Success;
		}

		private Status ValidateCell (int x, int y)
		{
			return engine.field.IsSuitable(x, y) ? Status.Success : Status.NoSuchCell;
		}

		public bool IsCardExists (int id)
		{
			return GetCard(id) != null;
		}

		public bool IsCardOwned (int id)
		{
			return IsCardExists(id) && GetCard(id).IsControlledBy(chief);
		}

		private Status ValidateCommand (Target command)
		{
			return ValidateCards(command.sourceId, command.targetId);
		}

		private Status ValidateCommand (Position command)
		{
			var status = ValidateCard(command.cardId);

			if (status != Status.Success) {
				return status;
			}

			return ValidateCell(command.x, command.y);
		}

		private Status ValidateCommand (SingleCard command)
		{
			return ValidateCard(command.cardId);
		}

		public Status Deploy (Position command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var card = GetCard(command.cardId);

			if (card is FieldCard) {
				return manage.Deploy((FieldCard)card, engine.field.GetCell(command.x, command.y)).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status Deploy (SingleCard command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var card = GetCard(command.cardId);

			if (card is Platoon) {
				return manage.Deploy((Platoon)card).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status Move (Position command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var card = GetCard(command.cardId);

			if (card is FieldCard) {
				return manage.Move((FieldCard)card, engine.field.GetCell(command.x, command.y)).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status Attack (Target command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var source = GetCard(command.sourceId);
			var target = GetCard(command.targetId);

			if (source is FieldCard && target is FieldCard) {
				return manage.Fight((FieldCard)source, (FieldCard)target).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status Order (Target command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var source = GetCard(command.sourceId);
			var target = GetCard(command.targetId);

			if (source is Order && target is FieldCard) {
				return manage.Order((Order)source, (FieldCard)target).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status Order (SingleCard command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var source = GetCard(command.cardId);

			if (source is Order) {
				return manage.Order((Order)source).GetStatus();
			} else {
				return Status.WrongCardType;
			}
		}

		public Status EndTurn ()
		{
			return manage.EndTurn(chief).GetStatus();
		}

		public Status Surrender ()
		{
			return manage.Surrender(chief).GetStatus();
		}


	}
}
