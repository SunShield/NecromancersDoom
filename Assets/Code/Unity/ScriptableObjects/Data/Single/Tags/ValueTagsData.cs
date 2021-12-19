using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Single.Tags
{
	public class ValueTagsData : SerializedScriptableObject
	{
		[ListDrawerSettings(CustomAddFunction = "AddValueTagData", AlwaysAddDefaultValue = true, Expanded = true)]
		public List<ValueTagData> Tags = new List<ValueTagData>();

		public ValueTagData AddValueTagData()
		{
			return new ValueTagData()
			{
				Name = "New Tag",
				Ancestors = new List<string>()
			};
		}
	}
}