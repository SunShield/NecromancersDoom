using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Skills
{
	public class SkillParam
	{
		private const string BaseVerticalGroup = "Name";
		private const string DefaultValueVerticalGroup = "DefaultValue";
		private const string TagsVerticalGroup = "Tags";

		[VerticalGroup(BaseVerticalGroup)] 
		[HideLabel]
		[TableColumnWidth(200, Resizable = false)]
		public string Name;

		[VerticalGroup(DefaultValueVerticalGroup)]
		[HideLabel]
		[TableColumnWidth(80, Resizable = false)]
		public float DefaultValue;

		[VerticalGroup(TagsVerticalGroup)] 
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		public List<ThreeListTagHolder> Tags;
	}
}