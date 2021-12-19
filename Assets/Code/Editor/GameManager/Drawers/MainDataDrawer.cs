using NDoom.Unity.ScriptableObjects.Data.Single;

namespace NDoom.Editor.GameManager.Drawers
{
	public class MainDataDrawer : ScriptableObjectDrawer<MainDataSo>
	{
		protected override void RegisterAsset(MainDataSo asset)
		{
			AllData.m_mainDataSo = asset;
		}
	}
}