using System.Collections.Generic;
using NDoom.Unity.EntitySystem.Loadable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Battle
{
	public class BattleData : NamedData
	{
		private const string MainGroupName = "Main";
		private const string MainGroupHorizontal = MainGroupName + "/Hor";
		private const string BackgroundVerticalGroup = MainGroupHorizontal + "/Background";
		private const string DataVerticalGroupName = MainGroupHorizontal + "/Data";
		private const string BasicBattleDataFoldoutGroupName = DataVerticalGroupName + "/BasicBattleData";
		private const string BasicBattleDataHorizontalGroupName = BasicBattleDataFoldoutGroupName + "/BasicBattleData_H";
		private const string BattlefieldSizesDataVerticalGroupName = BasicBattleDataHorizontalGroupName + "/BattlefiendSizes";
		private const string BattleUnitsFoldoutGroupName = DataVerticalGroupName + "/Units";

		public override string DataName => Name;

		[BoxGroup(MainGroupName)][HorizontalGroup(MainGroupHorizontal, Width = 258)][VerticalGroup(BackgroundVerticalGroup)]
		[PreviewField(Alignment = ObjectFieldAlignment.Left, Height = 256)]
		[HideLabel]
		public Sprite Background;

		[VerticalGroup(DataVerticalGroupName)][FoldoutGroup(BasicBattleDataFoldoutGroupName)][HorizontalGroup(BasicBattleDataHorizontalGroupName)]
		[LabelWidth(50)]
		public string Name;

		[VerticalGroup(BattlefieldSizesDataVerticalGroupName)]
		[LabelWidth(120)]
		public Vector2Int LeftBattlefieldSize;

		[VerticalGroup(BattlefieldSizesDataVerticalGroupName)]
		[LabelWidth(120)]
		public Vector2Int RightBattlefieldSize;

		[FoldoutGroup(BattleUnitsFoldoutGroupName)]
		[TableList]
		public List<BattleDataUnit> Units;
	}
}