using NDoom.Unity.Environment.Debugging;
using NDoom.Core.Environment.EventSystem;
using NDoom.Core.Environment.EventSystem.Concrete.Args;
using NDoom.Core.Environment.EventSystem.Concrete.Events;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Environment.SceneManagement.Preparation
{
	public abstract class ScenePreparer : ExtendedMonoBehaviour, IInitializable
	{
		[Inject] private EventBus _eventBus;

		private string CurrentSceneName => gameObject.scene.name;

		public void Initialize()
		{
			PrepareSceneInternal();
			LogScenePrepared();
			FireOnPreparedEvent();
		}

		protected abstract void PrepareSceneInternal();

		private void LogScenePrepared() => GameDebugger.Log(GameDebugContext.PREPARATION, $"Scene {CurrentSceneName} prepared!");
		private void FireOnPreparedEvent() => _eventBus.GetEvent<OnScenePreparedEvent>().InvokeForGlobal(new SceneArgs(CurrentSceneName));
	}
}