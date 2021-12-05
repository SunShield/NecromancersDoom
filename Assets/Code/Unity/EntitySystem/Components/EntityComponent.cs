using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.EntitySystem.Components
{
	public abstract class EntityComponent<TEntity> : ExtendedMonoBehaviour
		where TEntity : Entity
	{
		protected TEntity Parent { get; private set; }

		public void Initialize(TEntity entity)
		{
			SetParent(entity);
			InitializeComponent();
		}

		private void SetParent(TEntity entity) => Parent = entity;

		protected virtual void InitializeComponent() { }
	}
}