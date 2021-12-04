using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem.Spawning.Args;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattleSpawnArgs : EntitySpawnArgs, IStructurableEntitySpawnArgs<BattleStructuralData>
	{
		public BattleStructuralData StructuralData { get; set; }
	}
}