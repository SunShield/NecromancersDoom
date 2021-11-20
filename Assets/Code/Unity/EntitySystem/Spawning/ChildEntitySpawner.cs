using NDoom.Unity.EntitySystem.Interfaces;
using NDoom.Unity.EntitySystem.Spawning.Args;

namespace NDoom.Unity.EntitySystem.Spawning
{
	public abstract class ChildEntitySpawner<TChild, TSpawnArgs, TAncestor> : EntitySpawner<TChild, TSpawnArgs>
		where TSpawnArgs : ChildEntitySpawnArgs<TAncestor, TChild>
		where TAncestor : IAncestorEntity<TChild, TAncestor>
		where TChild : Entity, IChildEntity<TAncestor, TChild>
	{
		protected sealed override void ProcessEntityPostCreate(TChild entity, TSpawnArgs args)
		{
			args.Ancestor.AddChild(entity);
			entity.BindToAncestor(args.Ancestor);
		}

		protected virtual void ProcessEntityPostChildBinding(TChild entity, TSpawnArgs args) {}
	}
}