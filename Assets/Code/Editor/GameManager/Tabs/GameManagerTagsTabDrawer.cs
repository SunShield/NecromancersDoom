using NDoom.Editor.GameManager.Drawers;
using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerTagsTabDrawer : GameManagerScriptableObjectTabDrawer<ValueTagsData>
	{
		public override bool HasMenuTree => true;
		protected override string DataPath => GameManagerConstants.ValueTagsDataPath;

		protected override ScriptableObjectDrawer<ValueTagsData> Drawer { get; } = new ValueTagsDataDrawer();
	}
}
