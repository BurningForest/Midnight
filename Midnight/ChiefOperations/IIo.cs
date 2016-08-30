using Midnight.Core;

namespace Midnight.ChiefOperations
{
	public interface IIo
	{
		Status Attack (Io.Target command);
		Status Deploy (Io.SingleCard command);
		Status Deploy (Io.Position command);
		Status Move   (Io.Position command);
		Status Order  (Io.Target command);
		Status Order  (Io.SingleCard command);
		Status EndTurn ();
        Status Surrender();
	}
}