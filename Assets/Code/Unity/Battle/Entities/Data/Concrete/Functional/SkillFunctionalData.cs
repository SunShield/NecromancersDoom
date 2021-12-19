using System.Collections.Generic;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Functional
{
	public class SkillFunctionalData : EntityFunctionalData
	{
		public float Prewarm { get; set; }
		public float Cooldown { get; set; }
		public float Duration { get; set; }
		public Dictionary<string, TaggedParameter> Parameters { get; set; }
	}
}