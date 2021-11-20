using Sirenix.OdinInspector.Editor;

namespace NDoom.Editor.GameManager.Tabs
{
	public abstract class GameManagerTabDrawer
	{
		protected GameManager Manager { get; private set; }

		public abstract object DrawableContent { get; }
		public abstract bool HasMenuTree { get; }

		public void Initialize(GameManager manager)
		{
			Manager = manager;
			InitializeInternal();
		}

		protected abstract void InitializeInternal();
		public abstract void OnMenuTree(OdinMenuTree tree);
		public abstract void OnDrawEditors();
	}
}
