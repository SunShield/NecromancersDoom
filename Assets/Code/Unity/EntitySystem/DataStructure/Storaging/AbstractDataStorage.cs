using System.Collections.Generic;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class AbstractDataStorage<TEntityData>
		where TEntityData : IEntityData
	{
		private readonly Dictionary<string, TEntityData> _data = new Dictionary<string, TEntityData>();

		public void Add(string name, TEntityData data) => _data.Add(name, data);
		public TEntityData this[string name] => _data[name];
	}
}
