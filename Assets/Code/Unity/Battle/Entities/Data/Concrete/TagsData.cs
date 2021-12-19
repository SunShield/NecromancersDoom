using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.ScriptableObjects.Data.Single.Tags;
using Sirenix.Utilities;

namespace NDoom.Unity.Battles.Entities.Data.Concrete
{
	public class TagsData
	{
		public Dictionary<string, ValueTag> Tags = new Dictionary<string, ValueTag>();

		public void Fill(ValueTagsData data)
		{
			var dataTagsDict = data.Tags.ToDictionary(tag => tag.Name);
			Tags = dataTagsDict.Keys.Select(tagName => new ValueTag(tagName)).ToDictionary(tag => tag.Name);
			Tags.Keys.ForEach(
				tag => dataTagsDict[tag].Ancestors.ForEach(
					ancestor => Tags[tag].Ancestors.Add(Tags[ancestor])));
		}
	}
}