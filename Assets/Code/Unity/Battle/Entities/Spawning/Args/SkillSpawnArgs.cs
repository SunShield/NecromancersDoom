using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Entities.Spawning.Args;
using NDoom.Unity.ScriptableObjects.Data.Skills;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class SkillSpawnArgs : IFullEntitySpawnArgs<SkillData, SkillLoadedSpawnData, SkillFunctionalData>
	{
		public Skill Prefab { get; private set; }
		public SkillFunctionalData FunctionalData { get; set; }

		public void GetDataFromSpawnData(SkillLoadedSpawnData spawnData)
		{
			Prefab = spawnData.Prefab;
		}
	}
}