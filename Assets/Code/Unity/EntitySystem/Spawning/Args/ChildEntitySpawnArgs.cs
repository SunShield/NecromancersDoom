using NDoom.Unity.EntitySystem.Interfaces;

namespace NDoom.Unity.EntitySystem.Spawning.Args
{
	public class ChildEntitySpawnArgs<TAncestor, TChild> : EntitySpawnArgs
		where TAncestor : IAncestorEntity<TChild, TAncestor>
		where TChild : IChildEntity<TAncestor, TChild>
	{
		public TAncestor Ancestor { get; set; }
	}
}