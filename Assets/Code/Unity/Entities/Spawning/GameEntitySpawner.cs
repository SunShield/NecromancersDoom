using NDoom.Core.DataManagement.Data.LocationData;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.Environment.Main;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Unity.Entities.Spawning
{
	public abstract class GameEntitySpawner<TGameEntity, TNamedData, TLocationData, TSpawnArgs, TInitArgs> : ExtendedMonoBehaviour
		where TGameEntity : GameEntityT<TNamedData, TLocationData, TInitArgs, TSpawnArgs>
		where TNamedData : NamedData
		where TLocationData : EntityLocationData<TNamedData>
		where TSpawnArgs : IGameEntitySpawnArgs
		where TInitArgs : IGameEntityInitArgs<TNamedData, TLocationData, TSpawnArgs>, new()
	{
		public TGameEntity Spawn(TLocationData locationData, TSpawnArgs spawnArgs)
		{
			var entity = CreateEntity(spawnArgs);
			var args = CreateInitArgs(locationData, spawnArgs);
			InitEntity(entity, args);
			RenameEntity(entity, args);
			PostEntitySpawn(entity, args);
			return entity;
		}

		protected virtual TGameEntity CreateEntity(TSpawnArgs args) => Instantiate(GetPrefab(args));
		protected abstract TGameEntity GetPrefab(TSpawnArgs args);

		private TInitArgs CreateInitArgs(TLocationData locationData, TSpawnArgs args)
		{
			var initArgs = new TInitArgs();;
			initArgs.FillFrom(locationData, args);
			return initArgs;
		}

		private void InitEntity(TGameEntity entity, TInitArgs args) => entity.InitializeWithArgs(args);
		protected virtual void RenameEntity(TGameEntity entity, TInitArgs args) {}
		protected virtual void PostEntitySpawn(TGameEntity entity, TInitArgs args) {}
	}
}