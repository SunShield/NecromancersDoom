using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.ScriptableObjects.Data.Battle;

namespace NDoom.Unity.Battles.Entities.Initialization
{
	public class BattleInitArgs
	{
		public int Rows { get; private set; }
		public int Cols { get; private set; }

		public void FillFrom(BattleSpawnArgs args)
		{

		}
	}
}