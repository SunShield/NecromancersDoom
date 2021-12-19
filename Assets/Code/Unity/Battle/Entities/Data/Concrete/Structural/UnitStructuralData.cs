using System.Collections.Generic;
using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Structural
{
	public class UnitStructuralData : EntityStructuralData
	{
		public List<(string skillName, Dictionary<string, float> parameterValues)> Skills { get; set; }
	}
}