using NDoom.Unity.ScriptableObjects.Data.Skills;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerSkillsTabDrawer : GameManagerScriptableObjectTabDrawer<SkillData>
	{
		protected override string DataPath => GameManagerConstants.SkillsDataPath;
	}
}