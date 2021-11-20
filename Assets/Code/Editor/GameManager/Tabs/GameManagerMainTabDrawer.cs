using Sirenix.OdinInspector.Editor;

namespace NDoom.Editor.GameManager.Tabs
{
	public class GameManagerMainTabDrawer : GameManagerTabDrawer
	{
		public override object DrawableContent => null;
		public override bool HasMenuTree => false;

		public override void OnDrawEditors()
		{
		}

		protected override void InitializeInternal()
		{
		}

		public override void OnMenuTree(OdinMenuTree tree)
		{
			throw new System.NotImplementedException();
		}
	}
}