using System.Collections.Generic;
using NDoom.Unity.Battles.Skills;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Skills
{
	public struct ThreeListParamHolder
	{
		private const string HorizontalGroup = "Horizontal";

		[HorizontalGroup(HorizontalGroup)]
		[HideLabel]
		[ValueDropdown("GetTagVaules")]
		public string Param1;

		[HorizontalGroup(HorizontalGroup)]
		[HideLabel]
		[ValueDropdown("GetTagVaules")]
		public string Param2;

		[HorizontalGroup(HorizontalGroup)]
		[HideLabel]
		[ValueDropdown("GetTagVaules")]
		public string Param3;

		private List<string> GetTagVaules() => SkillParamTagConstants.AllTags;
	}
}