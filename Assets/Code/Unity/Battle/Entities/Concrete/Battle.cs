using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities;
using NDoom.Unity.ScriptableObjects.Data.Battle;

namespace NDoom.Unity.Battles.Entities.Concrete
{
	public class Battle
	{
		public Battlefield LeftBattlefield { get; private set; }
		public Battlefield RightBattlefield { get; private set; }

		public void SetBattlefield(Battlefield battlefield)
		{
			if (battlefield.Side == BattlefieldSide.Left) LeftBattlefield = battlefield;
			else RightBattlefield = battlefield;
		}

		public Battlefield this[BattlefieldSide side] => side == BattlefieldSide.Left ? LeftBattlefield : RightBattlefield;
	}
}