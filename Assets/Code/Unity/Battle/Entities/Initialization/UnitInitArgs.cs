using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.ScriptableObjects.Data.Unit;

namespace NDoom.Unity.Battles.Entities.Initialization
{
	public class UnitInitArgs
	{
		public Tile Tile { get; set; }
		public UnitFunctionalData FunctionalData { get; set; }

		public void FillFrom(UnitSpawnArgs args)
		{
			Tile = args.Tile;
			FunctionalData = args.FunctionalData;
		}
	}
}