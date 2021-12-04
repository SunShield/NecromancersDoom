using NDoom.Unity.EntitySystem.DataStructure.Data;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Structural
{
	public class BattleStructuralData : EntityStructuralData
	{
		public Vector2 LeftBattlefieldOffset { get; set; }
		public Vector2 RightBattlefieldOffset { get; set; }
		public Vector2Int LeftBattlefieldSize { get; set; }
		public Vector2Int RightBattlefieldSize { get; set; }
	}
}