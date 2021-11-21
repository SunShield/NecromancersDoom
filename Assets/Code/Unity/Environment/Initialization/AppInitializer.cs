using NDoom.Unity.EntitySystem;
using NDoom.Unity.Environment.Main;
using NDoom.Unity.Environment.SceneManagement;
using NDoom.Unity.Environment.SceneManagement.Switching;
using Zenject;

namespace NDoom.Unity.Environment.Initialization
{
	public class AppInitializer : ExtendedMonoBehaviour, IInitializable
	{
		[Inject] private GameSceneManager _gameSceneManager;
		[Inject] private EntitySystemMain _entitySystem;

		public void Initialize()
		{
			InitEntitySystem();
			StartBattle();
		}

		private void InitEntitySystem() => _entitySystem.InitializeSystem();
		private void StartBattle() => _gameSceneManager.LoadSceneByName(SceneConstants.BattleSceneName);
	}
}