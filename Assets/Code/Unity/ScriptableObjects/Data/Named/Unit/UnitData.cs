using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
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
		private const string UnitMainDataFoldoutGroupName = BasicDataVerticalGroupName + "/MainDataSo";
		private const string UnitSkillDataFoldoutGroupName = BasicDataVerticalGroupName + "/Skills";
		
		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicUnitDataFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public Sprite Graphics;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(UnitMainDataFoldoutGroupName)]
		[LabelWidth(45)]
		public string Name;

		[FoldoutGroup(UnitSkillDataFoldoutGroupName)]
		[ListDrawerSettings(NumberOfItemsPerPage = 1)]
		[ValueDropdown("GetSkills")]
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
				Skills = Skills.Select(skill => (skill.Name, skill.ParamValues)).ToList()
			};
		}

		public ValueDropdownList<UnitSkillData> GetSkills()
		{
			var result = new ValueDropdownList<UnitSkillData>();
			var skillsData = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset").Skills;
			foreach (var skillData in skillsData)
			{
				result.Add(skillData.Name, new UnitSkillData(skillData.Name, skillData.SkillParams.ToDictionary(param => param.Name, param => param.DefaultValue)));
			}
			return result;
		}
	}
}