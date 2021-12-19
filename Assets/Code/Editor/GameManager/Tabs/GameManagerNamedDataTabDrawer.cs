using NDoom.Editor.GameManager.Drawers;
using NDoom.Unity.EntitySystem.Loadable;
using Sirenix.OdinInspector.Editor;

namespace NDoom.Editor.GameManager.Tabs
{
	public abstract class GameManagerNamedDataTabDrawer<TData> : GameManagerTabDrawer
		where TData : NamedData
	{
		public NamedDataDrawer<TData> Drawer { get; private set; } = new NamedDataDrawer<TData>();
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