using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.ScriptableObjects.Data.Battle;

namespace NDoom.Core.DataManagement.DataStructure.Spawn
{
	public class BattleLoadedSpawnData : LoadedSpawnData<BattleData>
	{
		public int Rows { get; private set; }
		public int Cols { get; private set; }
		public List<(string unitName, BattlefieldSide side, int row, int col)> DefaultUnits { get; private set; }

		protected override void FillFromInternal(BattleData data)
		{
			Rows = data.Size.x;
			Cols = data.Size.y;
			DefaultUnits = data.Units.Select(unit => (unit.Name, unit.Side, unit.Position.Y, unit.Position.X)).ToList();
		}
	}
}