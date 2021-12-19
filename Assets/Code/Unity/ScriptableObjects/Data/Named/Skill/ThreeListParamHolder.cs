using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.ScriptableObjects.Data.Single;
using Sirenix.OdinInspector;
using UnityEditor;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Skills
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

		private List<string> GetTagVaules()
		{
			// TODO: Later, move this data structure to the Editor and create a separate runtime-only data structure?
			// Or find another approach to get rid of this reference;
			var data = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset");
			var tags = data.TagsData.Tags;
			if (tags == null || tags.Count < 1) return null;
			return data.TagsData.Tags.Select(tag => tag.Name).ToList();
		}
	}
}