using NDoom.Unity.ScriptableObjects.Data.Named.Skills;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerSkillsTabDrawer : GameManagerNamedDataTabDrawer<SkillData>
	{
		protected override string DataPath => GameManagerConstants.SkillsDataPath;
	}
}