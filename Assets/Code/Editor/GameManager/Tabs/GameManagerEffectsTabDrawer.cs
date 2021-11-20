using NDoom.Unity.ScriptableObjects.Data.Effect;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerEffectsTabDrawer : GameManagerScriptableObjectTabDrawer<EffectData>
	{
		protected override string DataPath => GameManagerConstants.EffectsDataPath;
	}
}