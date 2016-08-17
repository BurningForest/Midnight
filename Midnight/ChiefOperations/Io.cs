using Midnight.Cards;
using Midnight.Cards.Types;
using Midnight.ChiefOperations.IoOptions;
using Midnight.Core;

namespace Midnight.ChiefOperations
{
	public class Io : IIo
	{
		public class Target
		{
			public int SourceId { get; set; }
			public int TargetId { get; set; }
		}

		public class SingleCard
		{
			public int CardId { get; set; }
		}

		public class Position
		{
			public int CardId { get; set; }
			public int X { get; set; }
			public int Y { get; set; }
		}

		private readonly Chief _chief;
		private Engine _engine;
		private Manage _manage;
	    public Options Options { get; }

	    public Io (Chief chief)
		{
			_chief = chief;

			Options = new Options(chief);
		}

		private Card GetCard (int id)
		{
			return id == 0
				? null
				: _engine.cache.Get(id);
		}

		public void SetEngine (Engine engine)
		{
			this._engine = engine;
			_manage = new Manage(engine);
		}

		private Status ValidateCards (int sourceId, int target)
		{
		    return !IsCardExists(target) ? Status.NoTargetCard : ValidateCard(sourceId);
		}

	    private Status ValidateCard (int sourceId)
		{
			if (!IsCardExists(sourceId))
            {
				return Status.NoSourceCard;
			}

			return !IsCardOwned(sourceId) ? Status.WrongCardOwner : Status.Success;
		}

		private Status ValidateCell (int x, int y)
		{
			return _engine.field.IsSuitable(x, y) ? Status.Success : Status.NoSuchCell;
		}

		public bool IsCardExists (int id)
		{
			return GetCard(id) != null;
		}

		public bool IsCardOwned (int id)
		{
			return IsCardExists(id) && GetCard(id).IsControlledBy(_chief);
		}

		private Status ValidateCommand (Target command)
		{
			return ValidateCards(command.SourceId, command.TargetId);
		}

		private Status ValidateCommand (Position command)
		{
			var status = ValidateCard(command.CardId);

			return status != Status.Success ? status : ValidateCell(command.X, command.Y);
		}

		private Status ValidateCommand (SingleCard command)
		{
			return ValidateCard(command.CardId);
		}

		public Status Deploy (Position command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var card = GetCard(command.CardId);

		    var fieldCard = card as FieldCard;
		    return fieldCard != null ? _manage.Deploy(fieldCard, _engine.field.GetCell(command.X, command.Y)).GetStatus() : Status.WrongCardType;
		}

		public Status Deploy (SingleCard command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success)
            {
				return status;
			}

			var card = GetCard(command.CardId);

		    var platoon = card as Platoon;
		    return platoon != null ? _manage.Deploy(platoon).GetStatus() : Status.WrongCardType;
		}

		public Status Move (Position command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var card = GetCard(command.CardId);

		    var fieldCard = card as FieldCard;
		    return fieldCard != null ? _manage.Move(fieldCard, _engine.field.GetCell(command.X, command.Y)).GetStatus() : Status.WrongCardType;
		}

		public Status Attack (Target command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) {
				return status;
			}

			var source = GetCard(command.SourceId);
			var target = GetCard(command.TargetId);

		    var card = source as FieldCard;
		    return card != null && target is FieldCard
		        ? _manage.Fight(card, (FieldCard) target).GetStatus()
		        : Status.WrongCardType;
		}

		public Status Order (Target command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success)
            {
				return status;
			}

			var source = GetCard(command.SourceId);
			var target = GetCard(command.TargetId);

		    var order = source as Order;
		    return order != null && target is FieldCard
		        ? _manage.Order(order, (FieldCard) target).GetStatus()
		        : Status.WrongCardType;
		}

		public Status Order (SingleCard command)
		{
			var status = ValidateCommand(command);

			if (status != Status.Success) return status;

			var source = GetCard(command.CardId);

		    var order = source as Order;
		    return order != null ? _manage.Order(order).GetStatus() : Status.WrongCardType;
		}

		public Status StartGame ()
		{
			return _manage.StartGame(_chief).GetStatus();
		}

		public Status EndTurn ()
		{
			return _chief.IsTurnOwner() ? _manage.EndTurn(_chief).GetStatus() : Status.NotTurnOfSource;
		}

		public Status Surrender ()
		{
			return _manage.Surrender(_chief).GetStatus();
		}


	}
}
