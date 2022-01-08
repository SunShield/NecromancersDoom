using System.Collections.Generic;
using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Functional
{
	public class SkillFunctionalData : EntityFunctionalData
	{
		public int PrewarmTicks { get; set; }
		public int CooldownTicks { get; set; }
		public float Duration { get; set; }

		public UnitResourceType ResourceType { get; set; }
		public float Cost { get; set; }

		public Dictionary<string, TaggedParameter> Parameters { get; set; }
		public Dictionary<string, Affector> AffectorPrefabs { get; set; }
	}
}