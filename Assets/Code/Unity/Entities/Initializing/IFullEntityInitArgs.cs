using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Initializing
{
	public interface IFullEntityInitArgs<TNamedData, TLocationData, TSpawnData, TFunctionalData, TFullEntitySpawnArgs> 
		: ISpawnableEntityInitArgs<TNamedData, TLocationData, TSpawnData, TFullEntitySpawnArgs>, 
			IFunctionalEntityInitArgs<TNamedData, TLocationData, TFunctionalData, TFullEntitySpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnData : LoadedSpawnData<TNamedData>
		where TFunctionalData : FunctionalDataT<TNamedData>
		where TFullEntitySpawnArgs : IFullEntitySpawnArgs<TNamedData, TSpawnData, TFunctionalData>
	{
	}
}