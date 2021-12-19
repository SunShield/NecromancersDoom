using NDoom.Editor.GameManager.Drawers;
using NDoom.Unity.ScriptableObjects.Data.Single;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerMainTabDrawer : GameManagerScriptableObjectTabDrawer<MainDataSo>
	{
		public override bool HasMenuTree => false;
		protected override ScriptableObjectDrawer<MainDataSo> Drawer { get; } = new MainDataDrawer();
		protected override string DataPath => GameManagerConstants.MainDataPath;
	}
}