using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.ScriptableObjects.Data.Unit;

namespace NDoom.Core.DataManagement.DataStructure.Spawn
{
	public class UnitLoadedSpawnData : LoadedSpawnData<UnitData>
	{
		public Unit Prefab { get; private set; }

		protected sealed override void FillFromInternal(UnitData data)
		{
			Prefab = data.Prefab;
		}
	}
}