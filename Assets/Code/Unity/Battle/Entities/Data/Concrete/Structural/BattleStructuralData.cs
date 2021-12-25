using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.EntitySystem.DataStructure.Data;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Structural
{
	public class BattleStructuralData : EntityStructuralData
	{
		public Dictionary<BattlefieldSide, (Vector2Int battlefieldSize, Vector2 battlefieldOffset)> BattlefieldDatas;
		public List<(string unitName, int row, int col)> LeftUnitDatas;
		public List<(string unitName, int row, int col)> RightUnitDatas;
	}
}