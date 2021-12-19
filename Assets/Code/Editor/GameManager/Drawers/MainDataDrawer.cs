using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Editor.GameManager.Drawers
{
	public class MainDataDrawer : ScriptableObjectDrawer<MainData>
	{
		protected override void RegisterAsset(MainData asset)
		{
			AllData.MainData = asset;
		}
	}
}