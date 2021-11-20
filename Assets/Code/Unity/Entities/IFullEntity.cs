using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities
{
	public interface IFullEntity<TNamedData, TLocationData, TSpawnData, TFunctionalData, TInitArgs, TSpawnArgs> 
		: IFunctionalEntity<TNamedData, TLocationData, TFunctionalData, TInitArgs, TSpawnArgs>, 
			ISpawnableEntity<TNamedData, TLocationData, TSpawnData, TInitArgs, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnData : LoadedSpawnData<TNamedData>
		where TFunctionalData : FunctionalDataT<TNamedData>
		where TInitArgs : IFullEntityInitArgs<TNamedData, TLocationData, TSpawnData, TFunctionalData, TSpawnArgs>
		where TSpawnArgs : IFullEntitySpawnArgs<TNamedData, TSpawnData, TFunctionalData>
	{
		
	}
}