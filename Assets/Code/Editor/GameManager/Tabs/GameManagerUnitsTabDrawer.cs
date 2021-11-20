using NDoom.Unity.ScriptableObjects.Data.Unit;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerUnitsTabDrawer : GameManagerScriptableObjectTabDrawer<UnitData>
	{
		protected override string DataPath => GameManagerConstants.UnitsDataPath;
	}
}