using NDoom.Unity.ScriptableObjects.Data.Named.Battle;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerBattlesTabDrawer : GameManagerNamedDataTabDrawer<BattleData>
	{
		protected override string DataPath => GameManagerConstants.BattlesDataPath;
	}
}