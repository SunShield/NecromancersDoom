using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using NDoom.Unity.ScriptableObjects.Data.Single;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Unit
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
		private const string UnitMainDataHorGroupName = UnitMainDataFoldoutGroupName + "/Horizantal";
		private const string MainDataBaseDataVerticalGroupName = UnitMainDataHorGroupName + "/Base";
		private const string ResourceDataBaseDataVerticalGroupName = UnitMainDataHorGroupName + "/Resources";
		private const string UnitSkillDataFoldoutGroupName = BasicDataVerticalGroupName + "/Skills";
		
		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicUnitDataFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public Sprite Graphics;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(UnitMainDataFoldoutGroupName)]
		[LabelWidth(45)]
		public string Name;

		[FoldoutGroup(UnitMainDataFoldoutGroupName)][HorizontalGroup(UnitMainDataHorGroupName, Width = 120)][VerticalGroup(MainDataBaseDataVerticalGroupName)]
		[LabelWidth(80)]
		public int MaxHealth;

		[HorizontalGroup(UnitMainDataHorGroupName, Width = 100)][VerticalGroup(ResourceDataBaseDataVerticalGroupName)]
		[HideLabel]
		public UnitResourceType ResourceType;

		[VerticalGroup(ResourceDataBaseDataVerticalGroupName)]
		[LabelWidth(110)]
		public int StartingResource;

		[VerticalGroup(ResourceDataBaseDataVerticalGroupName)]
		[LabelWidth(100)]
		public int MaxResource;

		[VerticalGroup(ResourceDataBaseDataVerticalGroupName)]
		[LabelWidth(100)]
		public int ResourceRegen;

		[FoldoutGroup(UnitSkillDataFoldoutGroupName)]
		[ListDrawerSettings(NumberOfItemsPerPage = 1)]
		[ValueDropdown("GetSkills")]
		[TableList]
		public List<UnitSkillData> Skills = new List<UnitSkillData>();

		public UnitGraphicalData ToGraphicalData()
		{
			return new UnitGraphicalData()
			{
				Graphics = Graphics
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
				Skills = Skills.Select(skill => (skill.Name, 
					skill.ParamValues.ToDictionary(paramValue => paramValue.Name, 
						                           paramValue => paramValue.Value))).ToList()
			};
		}

		public ValueDropdownList<UnitSkillData> GetSkills()
		{
			var result = new ValueDropdownList<UnitSkillData>();
			var skillsData = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset").Skills;
			foreach (var skillData in skillsData)
			{
				result.Add(skillData.Name, 
					new UnitSkillData(skillData.Name, 
						skillData.SkillParams.Select(param => (param.Name, param.DefaultValue)).ToList()));
			}
			return result;
		}
	}
}