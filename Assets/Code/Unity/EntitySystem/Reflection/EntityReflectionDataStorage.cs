using System;
using System.Collections.Generic;

namespace NDoom.Unity.EntitySystem.Reflection
{
	public class EntityReflectionDataStorage
	{
		private Dictionary<Type, EntityReflectionData> _entitiesReflectionDatas =
			new Dictionary<Type, EntityReflectionData>();

		public void Fill(Dictionary<Type, EntityReflectionData> datas) => _entitiesReflectionDatas = datas;
		public bool Contains(Type type) => _entitiesReflectionDatas.ContainsKey(type);

		public EntityReflectionData this[Type type] => _entitiesReflectionDatas[type];
		public EntityReflectionData this[Entity entity] => this[entity.GetType()];
	}
}