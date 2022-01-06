using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;

namespace NDoom.Core.EventSystem.Concrete.Args
{
	public class PlayerTickArgs : GameEventArgs
	{
		public BattlefieldSide PlayerSide;
	}
}
