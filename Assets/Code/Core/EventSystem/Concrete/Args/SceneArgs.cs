namespace NDoom.Core.Environment.EventSystem.Concrete.Args
{
	public class SceneArgs : GameEventArgs
	{
		public string SceneName { get; private set; }

		public SceneArgs(string sceneName) => SceneName = sceneName;
	}
}
