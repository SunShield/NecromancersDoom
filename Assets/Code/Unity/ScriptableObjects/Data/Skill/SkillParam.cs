using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Skills
{
	public class SkillParam
	{
		private const string BaseVerticalGroup = "Name";
		private const string TagsVerticalGroup = "Tags";

		[VerticalGroup(BaseVerticalGroup)] 
		[HideLabel]
		public string Name;

		[VerticalGroup(TagsVerticalGroup)] 
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		public List<ThreeListParamHolder> Tags;
	}
}