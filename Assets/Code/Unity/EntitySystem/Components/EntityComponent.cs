using NDoom.Unity.Battle.Environment.Players.Ticking;

namespace NDoom.Unity.EntitySystem.Components
{
	public abstract class EntityComponent<TEntity> : TickableBehaviour
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