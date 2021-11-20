using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Initializing
{
	public interface IFunctionalEntityInitArgs<TNamedData, TLocationData, TFunctionalData, TFunctionalEntitySpawnArgs> 
		: IGameEntityInitArgs<TNamedData, TLocationData, TFunctionalEntitySpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TFunctionalData : FunctionalDataT<TNamedData>
		where TFunctionalEntitySpawnArgs : IFunctionalEntitySpawnArgs<TNamedData, TFunctionalData>
	{
		public TFunctionalData FunctionalData { get; }
	}
}