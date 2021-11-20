using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data.Battle;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattleSpawnArgs : ISpawnableEntitySpawnArgs<BattleData, BattleLoadedSpawnData>
	{
		public int BattlefieldRows { get; private set; }
		public int BattlefieldCols { get; private set; }

		public void GetDataFromSpawnData(BattleLoadedSpawnData spawnData)
		{
			BattlefieldRows = spawnData.Rows;
			BattlefieldCols = spawnData.Cols;
		}
	}
}