using System.Collections.Generic;
using NDoom.Unity.ScriptableObjects.Data.Named.Battle;

namespace NDoom.Editor.GameManager.Drawers.Named
{
	public class BattleDataDrawer : NamedDataDrawer<BattleData>
	{
		protected override void ProcessPostCreate(BattleData data)
		{
			data.LeftUnits = new List<BattleDataUnit>();
			data.RightUnits = new List<BattleDataUnit>();
		}
	}
}