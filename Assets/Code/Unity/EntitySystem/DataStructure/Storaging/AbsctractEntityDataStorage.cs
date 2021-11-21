using System;
using System.Collections.Generic;
using NDoom.Unity.EntitySystem.Reflection;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class AbsctractEntityDataStorage<TEntityData>
		where TEntityData : IEntityData
	{
		private readonly Dictionary<Type, Dictionary<string, IEntityData>> _storages 
			= new Dictionary<Type, Dictionary<string, IEntityData>>();
		private readonly Dictionary<Type, Type> _datasTypeMap 
			= new Dictionary<Type, Type>();

		protected abstract Func<EntityReflectionData, bool> ReflectionDataCheckDelegate { get; }
		protected abstract Func<EntityReflectionData, Type> GetTypeForDataTypeMapDelegate { get; }

		public void InitStorages(List<EntityReflectionData> data)
		{
			foreach (var entityReflectionData in data)
			{
				if (!ReflectionDataCheckDelegate(entityReflectionData)) continue;
				AddStorage(entityReflectionData.EntityType);
				AddTypeToDataTypesMap(GetTypeForDataTypeMapDelegate(entityReflectionData), entityReflectionData.EntityType);
			}
		}

		private void AddStorage(Type type)
			=> _storages.Add(type, new Dictionary<string, IEntityData>());

		private void AddTypeToDataTypesMap(Type dataType, Type entityType)
			=> _datasTypeMap.Add(dataType, entityType);

		public void Add(string name, TEntityData graphicalData)
		{
			var type = graphicalData.GetType();
			_storages[_datasTypeMap[type]][name] = graphicalData;
		}

		public IEntityData Get(Entity entity) => _storages[entity.GetType()][entity.Name];
		public IEntityData Get(Type type, string name) => _storages[type][name];
	}
}