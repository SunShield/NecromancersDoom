using NDoom.Unity.Data;
using NDoom.Unity.Environment.Main;
using NDoom.Unity.Environment.SceneManagement;
using NDoom.Unity.Environment.SceneManagement.Switching;
using Zenject;

namespace NDoom.Unity.Environment.Initialization
{
	public class AppInitializer : ExtendedMonoBehaviour, IInitializable
	{
		[Inject] private GameSceneManager _gameSceneManager;
		[Inject] private AllDataLoader _allDataLoader;

		public void Initialize()
		{
			LoadAllData();
			StartBattle();
		}

		private void LoadAllData() => _allDataLoader.LoadAllData();
		private void StartBattle() => _gameSceneManager.LoadSceneByName(SceneConstants.BattleSceneName);
	}
}