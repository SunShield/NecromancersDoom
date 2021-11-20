using System.Collections.Generic;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class EntityDataStorage<TEntityData>
		where TEntityData : IEntityData
	{
		private readonly Dictionary<string, TEntityData> m_datas = new Dictionary<string, TEntityData>();

		public void AddData(string entityName, TEntityData entityData) => m_datas.Add(entityName, entityData);
		public TEntityData this[string entityName] => m_datas[entityName];
	}
}