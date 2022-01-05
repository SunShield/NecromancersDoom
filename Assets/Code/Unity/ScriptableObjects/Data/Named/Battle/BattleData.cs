using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using NDoom.Unity.ScriptableObjects.Data.Single;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Battle
{
	public class BattleData 
		: NamedData,
			IStructuralDataConvertible<BattleStructuralData>,
			IGraphicalDataConvertible<BattleGraphicalData>
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
		private const string BattleUnitsHorizontalGroup = BattleUnitsFoldoutGroupName + "/Horizontal";

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

		[FoldoutGroup(BattleUnitsFoldoutGroupName)][HorizontalGroup(BattleUnitsHorizontalGroup)]
		[TableList(ShowPaging = true, NumberOfItemsPerPage = 5)]
		[ValueDropdown("GetUnitVariants", NumberOfItemsBeforeEnablingSearch = 5)]
		public List<BattleDataUnit> LeftUnits;

		[HorizontalGroup(BattleUnitsHorizontalGroup)]
		[TableList(ShowPaging = true, NumberOfItemsPerPage = 5)]
		[ValueDropdown("GetUnitVariants", NumberOfItemsBeforeEnablingSearch = 5)]
		public List<BattleDataUnit> RightUnits;

		public BattleGraphicalData ToGraphicalData()
		{
			return new BattleGraphicalData()
			{
				Prefab = Background
			};
		}

		public BattleStructuralData ToStructuralData()
		{
			return new BattleStructuralData()
			{
				BattlefieldDatas = new Dictionary<BattlefieldSide, (Vector2Int battlefieldSize, Vector2 battlefieldOffset)>()
				{
					{ BattlefieldSide.Left,  (LeftBattlefieldSize,  LeftBattlefieldOffset) },
					{ BattlefieldSide.Right, (RightBattlefieldSize, RightBattlefieldOffset) }
				},
				LeftUnitDatas =  LeftUnits.Select(dataUnit => (dataUnit.Name, dataUnit.Position.Y, dataUnit.Position.X)).ToList(),
				RightUnitDatas = RightUnits.Select(dataUnit => (dataUnit.Name, dataUnit.Position.Y, dataUnit.Position.X)).ToList()
			};
		}

		private ValueDropdownList<BattleDataUnit> GetUnitVariants()
		{
			var data = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset");
			var units = data.Units;
			if (units == null || units.Count < 1) return null;
			var result = new ValueDropdownList<BattleDataUnit>();
			foreach (var unitData in units)
			{
				result.Add(unitData.Name, new BattleDataUnit() { Name = unitData.Name });
			}
			return result;
		}
	}
}