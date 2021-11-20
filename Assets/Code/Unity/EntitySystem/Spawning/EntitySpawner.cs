using NDoom.Unity.EntitySystem.Spawning.Args;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.EntitySystem.Spawning
{
	public abstract class EntitySpawner<TEntity, TSpawnArgs> : ExtendedMonoBehaviour
		where TEntity : Entity
		where TSpawnArgs : EntitySpawnArgs
	{
		[Inject] private DiContainer _container;

		public TEntity Spawn(TSpawnArgs args)
		{
			TEntity entity = CreateEntity(args.Name);
			ProcessEntityPostCreate(entity, args);
			return entity;
		}

		public TEntity CreateEntity(string name)
		{
			var entity = _container.InstantiatePrefab(GetPrefab(name));
			entity.name = GetEntityName(name);
			return entity.GetComponent<TEntity>();
		}
		
		protected abstract TEntity GetPrefab(string name);
		protected abstract string GetEntityName(string name);
		protected abstract void ProcessEntityPostCreate(TEntity entity, TSpawnArgs args);
	}
}