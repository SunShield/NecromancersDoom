using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities
{
	// TODO: Bad naming. It refers to "LoadedSpawnData", but class name is misleading.
	public interface ISpawnableEntity<TNamedData, TLocationData, TSpawnData, TInitArgs, TSpawnArgs> 
		: IGameEntity<TNamedData, TLocationData, TInitArgs, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnData : LoadedSpawnData<TNamedData>
		where TInitArgs : ISpawnableEntityInitArgs<TNamedData, TLocationData, TSpawnData, TSpawnArgs>
		where TSpawnArgs : ISpawnableEntitySpawnArgs<TNamedData, TSpawnData>
	{
	}
}