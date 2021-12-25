using NDoom.Editor.GameManager.Drawers;
using NDoom.Editor.GameManager.Drawers.Named;
using NDoom.Unity.ScriptableObjects.Data.Named.Battle;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerBattlesTabDrawer : GameManagerNamedDataTabDrawer<BattleData>
	{
		public override NamedDataDrawer<BattleData> Drawer { get; } = new BattleDataDrawer();

		protected override string DataPath => GameManagerConstants.BattlesDataPath;
	}
}