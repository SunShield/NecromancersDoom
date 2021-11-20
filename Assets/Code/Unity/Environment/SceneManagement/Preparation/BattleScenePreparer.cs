using NDoom.Unity.Battles;
using Zenject;

namespace NDoom.Unity.Environment.SceneManagement.Preparation
{
	public class BattleScenePreparer : ScenePreparer
	{
		[Inject] private BattleStarter _battle;

		protected override void PrepareSceneInternal()
		{
			_battle.StartBattle("TestBattle");
		}
	}
}