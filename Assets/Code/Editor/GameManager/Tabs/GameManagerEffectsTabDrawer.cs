using NDoom.Unity.ScriptableObjects.Data.Effect;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerEffectsTabDrawer : GameManagerNamedDataTabDrawer<EffectData>
	{
		protected override string DataPath => GameManagerConstants.EffectsDataPath;
	}
}