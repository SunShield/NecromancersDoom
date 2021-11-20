using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Concrete;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Skills
{
	public class SkillData : NamedData
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
		public Skill Prefab;

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
		[TableList]
		public List<SkillParam> SkillParams;

		[VerticalGroup(BasicDataVerticalGroupName)] [TableList]
		public List<SkillAffectorData> Affectors;
	}
}