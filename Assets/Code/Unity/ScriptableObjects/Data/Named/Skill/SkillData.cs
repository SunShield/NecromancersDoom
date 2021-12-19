using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Skills
{
	public class SkillData : 
		NamedData, 
		IGraphicalDataConvertible<SkillGraphicalData>, 
		IFunctionalDataConvertible<SkillFunctionalData>
	{
		private const string MainVerticalGroupName = "Skill";
		private const string BasicSkillDataFoldoutGroupName = MainVerticalGroupName + "/Basic Data";
		private const string BasicDataHorizontalGroupName = BasicSkillDataFoldoutGroupName + "/Horizontal";
		private const string BasicDataVerticalGroupName = BasicDataHorizontalGroupName + "/Vertical";
		private const string BasicDataVerticalFoldoutGroupName = BasicDataVerticalGroupName +  "/Base Data";
		private const string BasicDataCooldownHorizontalGroup = BasicDataVerticalFoldoutGroupName + "/Cooldown";

		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicSkillDataFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public GameObject Prefab;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(BasicDataVerticalFoldoutGroupName)]
		[LabelWidth(45)]
		public string Name;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(BasicDataVerticalFoldoutGroupName)][HorizontalGroup(BasicDataCooldownHorizontalGroup)]
		[LabelWidth(65)]
		public float Prewarm;

		[VerticalGroup(BasicDataVerticalGroupName)][HorizontalGroup(BasicDataCooldownHorizontalGroup)]
		[LabelWidth(65)]
		public float Cooldown;

		[VerticalGroup(BasicDataVerticalGroupName)][HorizontalGroup(BasicDataCooldownHorizontalGroup)]
		[LabelWidth(65)]
		public float Duration;

		[VerticalGroup(BasicDataVerticalGroupName)]
		[TableList(ShowPaging = true, NumberOfItemsPerPage = 3)]
		public List<SkillParam> SkillParams = new List<SkillParam>();

		[VerticalGroup(BasicDataVerticalGroupName)] [TableList]
		public List<SkillAffectorData> Affectors = new List<SkillAffectorData>();

		public SkillGraphicalData ToGraphicalData()
		{
			return new SkillGraphicalData() { Prefab = Prefab };
		}

		public SkillFunctionalData ToFunctionalData()
		{
			return new SkillFunctionalData()
			{
				Prewarm = Prewarm,
				Cooldown = Cooldown,
				Duration = Duration
			};
		}
	}
}