using NDoom.Editor.GameManager.Drawers;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace NDoom.Editor.GameManager.Tabs
{
	public abstract class GameManagerScriptableObjectTabDrawer<TScriptableObject> : GameManagerTabDrawer
		where TScriptableObject : SerializedScriptableObject
	{
		protected abstract ScriptableObjectDrawer<TScriptableObject> Drawer { get; }
		public override object DrawableContent => Drawer;
		protected abstract string DataPath { get; }

		public override void OnDrawEditors()
		{
		}

		public override void OnMenuTree(OdinMenuTree tree)
		{
		}

		protected override void InitializeInternal()
		{
			Drawer.Initialize();
			Drawer.SetDrawnItem(DataPath);
		}
	}
}