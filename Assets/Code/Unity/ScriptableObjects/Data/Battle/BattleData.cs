using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Battle
{
	public class BattleData : NamedData, IGraphicalDataConvertible<BattleGraphicalData>
	{
		private const string MainGroupName = "Main";
		private const string MainGroupHorizontal = MainGroupName + "/Hor";
		private const string BackgroundVerticalGroup = MainGroupHorizontal + "/Background";
		private const string DataVerticalGroupName = MainGroupHorizontal + "/Data";
		private const string BasicBattleDataFoldoutGroupName = DataVerticalGroupName + "/BasicBattleData";
		private const string BasicBattleDataHorizontalGroupName = BasicBattleDataFoldoutGroupName + "/BasicBattleData_H";
		private const string LeftBattlefieldDataVerticalGroupName = BasicBattleDataHorizontalGroupName + "/LeftBattlefield";
		private const string RightBattlefieldDataVerticalGroupName = BasicBattleDataHorizontalGroupName + "/RightBattlefield";
		private const string BattleUnitsFoldoutGroupName = DataVerticalGroupName + "/Units";

		public override string DataName => Name;

		[BoxGroup(MainGroupName)][HorizontalGroup(MainGroupHorizontal, Width = 258)][VerticalGroup(BackgroundVerticalGroup)]
		[PreviewField(Alignment = ObjectFieldAlignment.Left, Height = 256)]
		[HideLabel]
		public GameObject Background;

		[VerticalGroup(DataVerticalGroupName)][FoldoutGroup(BasicBattleDataFoldoutGroupName)][HorizontalGroup(BasicBattleDataHorizontalGroupName, Width = 150)]
		[LabelWidth(50)]
		public string Name;

		[VerticalGroup(LeftBattlefieldDataVerticalGroupName)]
		[LabelWidth(130)]
		public Vector2Int LeftBattlefieldSize;

		[VerticalGroup(LeftBattlefieldDataVerticalGroupName)]
		[LabelWidth(130)]
		public Vector2 LeftBattlefieldOffset;

		[VerticalGroup(RightBattlefieldDataVerticalGroupName)]
		[LabelWidth(130)]
		public Vector2Int RightBattlefieldSize;

		[VerticalGroup(RightBattlefieldDataVerticalGroupName)]
		[LabelWidth(130)]
		public Vector2 RightBattlefieldOffset;

		[FoldoutGroup(BattleUnitsFoldoutGroupName)]
		[TableList(ShowPaging = true, NumberOfItemsPerPage = 5)]
		public List<BattleDataUnit> Units;

		public BattleGraphicalData ToGraphicalData()
		{
			return new BattleGraphicalData()
			{
				Prefab = Background
			};
		}
	}
}