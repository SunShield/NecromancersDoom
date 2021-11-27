using NDoom.Unity.EntitySystem.DataStructure.Data;
using NDoom.Unity.EntitySystem.Interfaces;
using NDoom.Unity.EntitySystem.Spawning.Args;

namespace NDoom.Unity.EntitySystem.Spawning
{
	public abstract class PositionableEntitySpawner<TPositionableEntity, TSpawnArgs, TAncestor, TPositionData> 
		: ChildEntitySpawner<TPositionableEntity, TSpawnArgs, TAncestor>
		where TSpawnArgs : PositionableEntitySpawnArgs<TAncestor, TPositionableEntity, TPositionData>
		where TAncestor : IAncestorEntity<TPositionableEntity, TAncestor>
		where TPositionableEntity : Entity, IPositionableEntity<TPositionData, TAncestor, TPositionableEntity>
		where TPositionData : EntityPositionData
	{
		protected sealed override void ProcessEntityPostChildBinding(TPositionableEntity entity, TSpawnArgs args)
		{
			entity.SetPosition(args.Position);
		}

		protected virtual void ProcessEntityPostPositionSet(TPositionableEntity entity, TSpawnArgs args) { }
	}
}