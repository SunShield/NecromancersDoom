using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Linq;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Unit
{
	public class UnitSkillData
	{
		private const string NameVerticalGroup = "Name";
		private const string ParamsVerticalGroup = "Params";

		[HorizontalGroup(NameVerticalGroup)]
		[HideLabel]
		[ReadOnly]
		public string Name;

		[HorizontalGroup(ParamsVerticalGroup)]
		[TableList]
		[ListDrawerSettings(HideAddButton = true)]
		public List<UnitSkillParamData> ParamValues;

		public UnitSkillData(string name, List<(string name, float value)> paramValues)
		{
			Name = name;
			ParamValues = (from paramValue in paramValues
						   select new UnitSkillParamData(paramValue.name, paramValue.value)).ToList();
		}
	}
}