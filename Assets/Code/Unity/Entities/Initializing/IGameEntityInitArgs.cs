using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Initializing
{
	public interface IGameEntityInitArgs<TNamedData, TLocationData, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnArgs : IGameEntitySpawnArgs
	{
		public void FillFrom(TLocationData locationData, TSpawnArgs args);
	}
}