using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities
{
	public interface IGameEntity<TNamedData, TLocationData, TInitArgs, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TInitArgs : IGameEntityInitArgs<TNamedData, TLocationData,TSpawnArgs>
		where TSpawnArgs : IGameEntitySpawnArgs
	{
		public abstract void InitializeWithArgs(TInitArgs args);
	}
}