using System.Collections.Generic;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Unit
{
	public class UnitSkillData
	{
		public string Name;

		public Dictionary<string, float> ParamValues;

		public UnitSkillData(string name, Dictionary<string, float> paramValues)
		{
			Name = name;
			ParamValues = new Dictionary<string, float>(paramValues);
		}
	}
}