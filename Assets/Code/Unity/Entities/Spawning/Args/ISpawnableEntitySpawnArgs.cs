using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Spawning.Args
{
	public interface ISpawnableEntitySpawnArgs<TNamedData, TSpawnData> : IGameEntitySpawnArgs
		where TNamedData : NamedData
		where TSpawnData : LoadedSpawnData<TNamedData>
	{
		public void GetDataFromSpawnData(TSpawnData spawnData);
	}
}