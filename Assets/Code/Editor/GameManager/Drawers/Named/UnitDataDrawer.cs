using NDoom.Unity.ScriptableObjects.Data.Named.Unit;

namespace NDoom.Editor.GameManager.Drawers.Named
{
	public class UnitDataDrawer : NamedDataDrawer<UnitData>
	{
		protected override void ProcessPostCreate(UnitData data)
		{
			data.Name = data.name;
		}
	}
}