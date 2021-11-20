using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.ScriptableObjects.Data.Skills;

namespace NDoom.Core.DataManagement.DataStructure.Spawn
{
	public class SkillLoadedSpawnData : LoadedSpawnData<SkillData>
	{
		public Skill Prefab { get; private set; }

		protected override void FillFromInternal(SkillData data) => Prefab = data.Prefab;
	}
}