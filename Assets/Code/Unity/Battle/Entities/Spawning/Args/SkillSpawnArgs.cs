using System.Collections.Generic;
using NDoom.Unity.EntitySystem.Spawning.Args;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class SkillSpawnArgs : ChildEntitySpawnArgs<Unit, Skill>
	{
		public Dictionary<string, float> ParamValues;
	}
}