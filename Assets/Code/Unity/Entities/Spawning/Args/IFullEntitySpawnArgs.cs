using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Spawning.Args
{
	public interface IFullEntitySpawnArgs<TNamedData, TSpawnData, TFunctionalData> 
		: ISpawnableEntitySpawnArgs<TNamedData, TSpawnData>, IFunctionalEntitySpawnArgs<TNamedData, TFunctionalData>
		where TNamedData : NamedData
		where TSpawnData : LoadedSpawnData<TNamedData>
		where TFunctionalData : FunctionalDataT<TNamedData>
	{
		
	}
}