using NDoom.Unity.EntitySystem.Interfaces;
using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.EntitySystem
{
	/// <summary>
	/// Main class for all the ESSENTIAL ingame objects.
	/// Entities are designed to be easily spawned, found and organized during runtime.
	/// There's no solid definition of what Entity actually is, but we may treat it as
	/// "Element, involved in certain game mechanics".
	/// </summary>
	public abstract class Entity : ExtendedMonoBehaviour, IEntity
	{
		private static int _currentId;
		private static int GetId() => _currentId++;

		public int GlobalId { get; private set; }
		public string Name { get; private set; }

		public void InitializeEntity(string name)
		{
			SetName(name);
			InitializeEntityPreSpawn();
		}

		public virtual void InitializeEntityPostSpawn() { }

		private void SetName(string name) => Name = name;
		protected virtual void InitializeEntityPreSpawn() {}

		protected sealed override void InitializeInternal() => SetId();
		protected void SetId() => GlobalId = GetId();
	}
}