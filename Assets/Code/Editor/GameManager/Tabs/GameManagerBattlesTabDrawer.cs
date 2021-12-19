using NDoom.Unity.ScriptableObjects.Data.Battle;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerBattlesTabDrawer : GameManagerNamedDataTabDrawer<BattleData>
	{
		protected override string DataPath => GameManagerConstants.BattlesDataPath;
	}
}