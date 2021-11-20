using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities.Initializing;

namespace NDoom.Unity.Battles.Entities.Initialization
{
	public class BattlefieldInitArgs
	{
		public int Rows { get; private set; }
		public int Cols { get; private set; }
		public BattlefieldSide Side { get; private set; }

		public void FillFrom(BattlefieldSpawnArgs spawnArgs)
		{
			Rows = spawnArgs.Rows;
			Cols = spawnArgs.Cols;
			Side = spawnArgs.Side;
		}
	}
}