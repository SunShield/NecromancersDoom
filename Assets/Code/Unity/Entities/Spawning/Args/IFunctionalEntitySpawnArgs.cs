using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Spawning.Args
{
	public interface IFunctionalEntitySpawnArgs<TNamedData, TFunctionalData> : IGameEntitySpawnArgs
		where TNamedData : NamedData
		where TFunctionalData : FunctionalDataT<TNamedData>
	{
		public TFunctionalData FunctionalData { get; }
	}
}