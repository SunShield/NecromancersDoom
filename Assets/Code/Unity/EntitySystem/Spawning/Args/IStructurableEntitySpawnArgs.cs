using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Spawning.Args
{
	public interface IStructurableEntitySpawnArgs<TStructuralData>
		where TStructuralData : EntityStructuralData
	{
		public TStructuralData StructuralData { get; set; }
	}
}