using NDoom.Core.DataManagement.Storaging;
using NDoom.Unity.Environment.Main;
using NDoom.Unity.Environment.SceneManagement;
using NDoom.Unity.Environment.SceneManagement.Switching;
using Zenject;

namespace NDoom.Unity.Environment.Initialization
{
	public class AppInitializer : ExtendedMonoBehaviour, IInitializable
	{
		[Inject] private DataStorageFiller _dataStorageFiller;
		[Inject] private GameSceneManager _gameSceneManager;

		public void Initialize()
		{
			LoadData();
			_gameSceneManager.LoadSceneByName(SceneConstants.BattleSceneName);
		}

		private void LoadData() => _dataStorageFiller.FillStorage();
	}
}