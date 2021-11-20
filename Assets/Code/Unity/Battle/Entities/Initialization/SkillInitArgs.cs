using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.ScriptableObjects.Data.Skills;

namespace NDoom.Unity.Battles.Entities.Initialization
{
	public class SkillInitArgs
	{
		public SkillFunctionalData FunctionalData { get; private set; }
	
		public void FillFrom(SkillSpawnArgs args)
		{
			FunctionalData = args.FunctionalData;
		}
	}
}