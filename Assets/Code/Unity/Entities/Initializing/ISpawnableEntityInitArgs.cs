using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Initializing
{
	public interface ISpawnableEntityInitArgs<TNamedData, TLocationData, TSpawnData, TSpawnableEntitySpawnArgs> 
		: IGameEntityInitArgs<TNamedData, TLocationData, TSpawnableEntitySpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnData : LoadedSpawnData<TNamedData>
		where TSpawnableEntitySpawnArgs : ISpawnableEntitySpawnArgs<TNamedData, TSpawnData>
	{
	}
}