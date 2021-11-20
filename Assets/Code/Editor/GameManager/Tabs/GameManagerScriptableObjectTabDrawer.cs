using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;

namespace NDoom.Editor.GameManager.Tabs
{
	public abstract class GameManagerScriptableObjectTabDrawer<TData> : GameManagerTabDrawer
		where TData : SerializedScriptableObject
	{
		public ScriptableObjectDrawer<TData> Drawer { get; private set; } = new ScriptableObjectDrawer<TData>();
		public sealed override object DrawableContent => Drawer;
		public sealed override bool HasMenuTree => true;

		protected abstract string DataPath { get; }

		public override void OnDrawEditors() => Drawer.SetSelected(Manager.MenuTree.Selection.SelectedValue);

		protected sealed override void InitializeInternal()
		{
			Drawer.Initialize();
			Drawer.SetPath(DataPath);
		}

		public override void OnMenuTree(OdinMenuTree tree)
		{
			tree.AddAllAssetsAtPath("", DataPath, typeof(TData));
		}
	}
}