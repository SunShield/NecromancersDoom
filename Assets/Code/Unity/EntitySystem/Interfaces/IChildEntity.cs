namespace NDoom.Unity.EntitySystem.Interfaces
{
	public interface IChildEntity<in TAncestor, TChild>
		where TAncestor : IAncestorEntity<TChild, TAncestor>
		where TChild : IChildEntity<TAncestor, TChild>
	{
		void BindToAncestor(TAncestor ancestor);
	}
}