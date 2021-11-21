using NDoom.Unity.EntitySystem.DataStructure.Storaging;
using NDoom.Unity.EntitySystem.Reflection;
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
		[Inject] private EntityReflectionDataStorage _reflectionDataStorage;
		[Inject] private FunctionalEntityDataStorage _functionalDataStorage;
		[Inject] private GraphicalEntityDataStorage _graphicalDataStorage;
		
		public TEntity Spawn(TSpawnArgs args)
		{
			TEntity entity = CreateEntity(args.Name);
			SetEntityGraphicalDataIfNeeded(entity);
			SetEntityFunctionalDataIfNeeded(entity);
			ProcessEntityPostCreate(entity, args);
			return entity;
		}

		public TEntity CreateEntity(string name)
		{
			var entity = _container.InstantiatePrefab(GetPrefab(name));
			entity.name = GetEntityName(name);
			return entity.GetComponent<TEntity>();
		}

		private void SetEntityGraphicalDataIfNeeded(TEntity entity)
		{
			var type = entity.GetType();
			if (!_reflectionDataStorage.Contains(type)) return;
			var graphicalData = _graphicalDataStorage.Get(entity);
			_reflectionDataStorage[type].GraphicalDataSetDelegate.DynamicInvoke(new object[] {entity, graphicalData});
		}

		private void SetEntityFunctionalDataIfNeeded(TEntity entity)
		{
			var type = entity.GetType();
			if (!_reflectionDataStorage.Contains(type)) return;
			var functionalData = _functionalDataStorage.Get(entity);
			_reflectionDataStorage[type].GraphicalDataSetDelegate.DynamicInvoke(new object[] {entity, functionalData});
		}

		protected abstract TEntity GetPrefab(string name);
		protected abstract string GetEntityName(string name);
		protected abstract void ProcessEntityPostCreate(TEntity entity, TSpawnArgs args);
	}
}