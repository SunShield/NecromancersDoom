using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Entities.Spawning.Args;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattlefieldSpawnArgs : IGameEntitySpawnArgs
	{
		public int Rows { get; private set; }
		public int Cols { get; private set; }
		public BattlefieldSide Side { get; private set; }
		public Battle Battle { get; private set; }

		public static BattlefieldSpawnArgs FromBattleSpawnArgs(BattleSpawnArgs args, BattlefieldSide side, Battle battle)
		{
			var spawnArgs = new BattlefieldSpawnArgs
			{
				Rows = args.BattlefieldRows, 
				Cols = args.BattlefieldCols, 
				Side = side, 
				Battle = battle
			};
			return spawnArgs;
		}
	}
}