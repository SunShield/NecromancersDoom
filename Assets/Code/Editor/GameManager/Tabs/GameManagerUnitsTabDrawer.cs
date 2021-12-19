using NDoom.Unity.ScriptableObjects.Data.Named.Unit;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerUnitsTabDrawer : GameManagerNamedDataTabDrawer<UnitData>
	{
		protected override string DataPath => GameManagerConstants.UnitsDataPath;
	}
}