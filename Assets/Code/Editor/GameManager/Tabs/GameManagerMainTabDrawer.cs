using NDoom.Editor.GameManager.Drawers;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerMainTabDrawer : GameManagerScriptableObjectTabDrawer<MainData>
	{
		public override bool HasMenuTree => false;
		protected override ScriptableObjectDrawer<MainData> Drawer { get; } = new MainDataDrawer();
		protected override string DataPath => GameManagerConstants.MainDataPath;
	}
}