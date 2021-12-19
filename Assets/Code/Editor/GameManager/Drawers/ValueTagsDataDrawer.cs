using NDoom.Unity.ScriptableObjects.Data.Single.Tags;

namespace NDoom.Editor.GameManager.Drawers
{
	public class ValueTagsDataDrawer : ScriptableObjectDrawer<ValueTagsData>
	{
		protected override void RegisterAsset(ValueTagsData asset)
		{
			AllData.TagsData = asset;
		}
	}
}