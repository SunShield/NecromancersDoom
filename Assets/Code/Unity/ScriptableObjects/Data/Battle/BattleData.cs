using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Battle
{
	public class BattleData : NamedData
	{
		private const string MainGroupName = "Main";
		private const string BasicBattleDataFoldoutGroupName = MainGroupName + "/BasicBattleData";
		private const string BasicBattleDataHorizontalGroupName = BasicBattleDataFoldoutGroupName + "/BasicBattleData_H";
		private const string BattleUnitsFoldoutGroupName = MainGroupName + "/Units";

		public override string DataName => Name;

		[BoxGroup(MainGroupName)][FoldoutGroup(BasicBattleDataFoldoutGroupName)][HorizontalGroup(BasicBattleDataHorizontalGroupName)]
		[LabelWidth(80)]
		public string Name;

		[HorizontalGroup(BasicBattleDataHorizontalGroupName, PaddingRight = 200)]
		[LabelWidth(80)]
		public Vector2Int Size;

		[FoldoutGroup(BattleUnitsFoldoutGroupName)]
		[TableList]
		public List<BattleDataUnit> Units;
	}
}