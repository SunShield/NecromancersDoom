using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;

namespace NDoom.Unity.ScriptableObjects.Data.Single.Tags
{
	public class ValueTagData
	{
		private const string MainGroupName = @"Main";
		private const string NameGroupName = MainGroupName + @"/Name";
		private const string AncestorsGroupName = MainGroupName + @"/Ancestors";

		[HorizontalGroup(MainGroupName)]/*[VerticalGroup(NameGroupName)]*/
		[HideLabel]
		[LabelWidth(100)]
		public string Name;

		[HorizontalGroup(MainGroupName)]/*[VerticalGroup(AncestorsGroupName)]*/
		[ValueDropdown("GetValues")]
		public List<string> Ancestors;

		public string[] GetValues()
		{
			// TODO: Later, move this data structure to the Editor and create a separate runtime-only data structure?
			// Or find another approach to get rid of this reference;
			var data = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset");
			var tags = data.TagsData.Tags;
			if (tags == null || tags.Count < 1) return null;
			return data.TagsData.Tags.Select(tag => tag.Name).ToArray();
		}
	}
}