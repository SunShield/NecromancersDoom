using System.Collections;
using System.Collections.Generic;
using NDoom.Core.Environment.EventSystem;
using NDoom.Core.Environment.EventSystem.Concrete.Args;
using NDoom.Core.Environment.EventSystem.Concrete.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace NDoom.Unity.Environment.SceneManagement.Switching
{
    public class GameSceneManager : MonoBehaviour
    {
	    [Inject] private EventBus _eventBus;
	    [Inject] private ZenjectSceneLoader _sceneLoader;

	    private readonly Stack<Scene> _openedScenes = new Stack<Scene>();

	    public void LoadSceneByName(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	    {
		    InvokeOnScenePreLoadedEvent(sceneName);
		    StartCoroutine(LoadSceneAsync(sceneName, loadSceneMode));
	    }

	    private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
	    {
			var loadOperation = _sceneLoader.LoadSceneAsync(sceneName, loadSceneMode);
			while (!loadOperation.isDone)
			{
				yield return null;
			}

			var scene = GetSceneByName(sceneName);
			StoreScene(scene, loadSceneMode);
			SetLastSceneActive();
			InvokeOnSceneLoadedEvent(sceneName);
	    }

		private Scene GetSceneByName(string _sceneName) => SceneManager.GetSceneByName(_sceneName);
	    private void SetLastSceneActive() => SceneManager.SetActiveScene(_openedScenes.Peek());

	    private void StoreScene(Scene scene, LoadSceneMode loadSceneMode)
	    {
			if(loadSceneMode == LoadSceneMode.Single)
				_openedScenes.Clear();

			_openedScenes.Push(scene);
	    }

	    public void UnloadLastScene() =>  StartCoroutine(UnloadLastSceneAsync());

	    private IEnumerator UnloadLastSceneAsync()
	    {
		    string sceneName = _openedScenes.Peek().name;
		    var unloadOperation = SceneManager.UnloadSceneAsync(_openedScenes.Peek());
		    while (!unloadOperation.isDone)
		    {
			    yield return null;
		    }

		    RemoveLastScene();
		    SetLastSceneActive();
		    InvokeOnSceneUnloadedEvent(sceneName);
	    }

	    private void RemoveLastScene() => _openedScenes.Pop();

		private void InvokeOnScenePreLoadedEvent(string sceneName) => _eventBus.GetEvent<OnScenePreLoadedEvent>().InvokeForGlobal(new SceneArgs(sceneName));
		private void InvokeOnSceneLoadedEvent(string sceneName) => _eventBus.GetEvent<OnSceneLoadedEvent>().InvokeForGlobal(new SceneArgs(sceneName));
		private void InvokeOnSceneUnloadedEvent(string sceneName) => _eventBus.GetEvent<OnSceneUnloadedEvent>().InvokeForGlobal(new SceneArgs(sceneName));
    }
}
