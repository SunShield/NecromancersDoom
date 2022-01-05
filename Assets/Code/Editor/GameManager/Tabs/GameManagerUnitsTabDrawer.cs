using NDoom.Editor.GameManager.Drawers;
using NDoom.Editor.GameManager.Drawers.Named;
using NDoom.Unity.ScriptableObjects.Data.Named.Unit;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerUnitsTabDrawer : GameManagerNamedDataTabDrawer<UnitData>
	{
		public override NamedDataDrawer<UnitData> Drawer { get; } = new UnitDataDrawer();
		protected override string DataPath => GameManagerConstants.UnitsDataPath;
	}
}