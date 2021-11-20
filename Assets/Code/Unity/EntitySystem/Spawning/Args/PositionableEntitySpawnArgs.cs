using NDoom.Unity.EntitySystem.DataStructure.Data;
using NDoom.Unity.EntitySystem.Interfaces;

namespace NDoom.Unity.EntitySystem.Spawning.Args
{
	public class PositionableEntitySpawnArgs<TAncestor, TChild, TPositionData> : ChildEntitySpawnArgs<TAncestor, TChild>
		where TAncestor : IAncestorEntity<TChild, TAncestor>
		where TChild : IChildEntity<TAncestor, TChild>
		where TPositionData : EntityPositionData
	{
		public TPositionData Position { get; set; }
	}
}