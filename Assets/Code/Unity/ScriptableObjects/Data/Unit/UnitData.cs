using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Unit
{
	public class UnitData 
		: NamedData, 
			IGraphicalDataConvertible<UnitGraphicalData>,
			IFunctionalDataConvertible<UnitFunctionalData>,
			IStructuralDataConvertible<UnitStructuralData>
	{
		private const string MainVerticalGroupName = "Unit";
		private const string BasicUnitDataFoldoutGroupName = MainVerticalGroupName + "/Basic Data";
		private const string BasicDataHorizontalGroupName = BasicUnitDataFoldoutGroupName + "/Horizontal";
		private const string BasicDataVerticalGroupName = BasicDataHorizontalGroupName + "/Vertical";
		private const string UnitMainDataFoldoutGroupName = BasicDataVerticalGroupName + "/MainData";
		private const string UnitSkillDataFoldoutGroupName = BasicDataVerticalGroupName + "/Skills";
		
		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicUnitDataFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public GameObject Prefab;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(UnitMainDataFoldoutGroupName)]
		[LabelWidth(45)]
		public string Name;

		[FoldoutGroup(UnitSkillDataFoldoutGroupName)]
		[TableList]
		public List<UnitSkillData> Skills = new List<UnitSkillData>();

		public UnitGraphicalData ToGraphicalData()
		{
			return new UnitGraphicalData()
			{
				Prefab = Prefab
			};
		}

		public UnitFunctionalData ToFunctionalData()
		{
			return new UnitFunctionalData();
		}

		public UnitStructuralData ToStructuralData()
		{
			return new UnitStructuralData()
			{
				Skills = Skills.Select(skill => skill.Name).ToList()
			};
		}
	}
}