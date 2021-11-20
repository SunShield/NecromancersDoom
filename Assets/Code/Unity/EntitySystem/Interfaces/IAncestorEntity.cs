namespace NDoom.Unity.EntitySystem.Interfaces
{
	public interface IAncestorEntity<in TChild, TAncestor> : IEntity
		where TChild : IChildEntity<TAncestor, TChild>
		where TAncestor : IAncestorEntity<TChild, TAncestor>
	{
		void AddChild(TChild entity);
		void RemoveChild(TChild entity);
	}
}