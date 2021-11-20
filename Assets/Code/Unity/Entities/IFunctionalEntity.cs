using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities
{
	public interface IFunctionalEntity<TNamedData, TLocationData, TFunctionalData, TInitArgs, TSpawnArgs> :
		IGameEntity<TNamedData, TLocationData,TInitArgs, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TFunctionalData : FunctionalDataT<TNamedData>
		where TInitArgs : IFunctionalEntityInitArgs<TNamedData, TLocationData, TFunctionalData, TSpawnArgs>
		where TSpawnArgs : IFunctionalEntitySpawnArgs<TNamedData, TFunctionalData>
	{
		public TFunctionalData FunctionalData { get; }
	}
}