using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data.Unit;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class UnitSpawnArgs : IFullEntitySpawnArgs<UnitData, UnitLoadedSpawnData, UnitFunctionalData>
	{
		public Tile Tile { get; set; }
		public Unit Prefab { get; set; }
		public UnitFunctionalData FunctionalData { get; set; }

		public UnitSpawnArgs(Tile tile, UnitLoadedSpawnData spawnData, UnitFunctionalData functionalData)
		{
			Tile = tile;
			FunctionalData = functionalData;
			GetDataFromSpawnData(spawnData);
		}

		public void GetDataFromSpawnData(UnitLoadedSpawnData spawnData)
		{
			Prefab = spawnData.Prefab;
		}
	}
}