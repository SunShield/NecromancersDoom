using System.Collections.Generic;
using System.Linq;
using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.EntitySystem.Loadable;
using NDoom.Unity.EntitySystem.Loadable.Interfaces;
using NDoom.Unity.ScriptableObjects.Data.Single;
using NDoom.Unity.ScriptableObjects.Data.Single.Tags;
using Sirenix.OdinInspector;
using UnityEditor;
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
		private const string SkillDataHorizontalGroupName = BasicSkillDataFoldoutGroupName + "/Horizontal";
		private const string BasicDataVerticalGroupName = SkillDataHorizontalGroupName + "/Vertical";
		private const string BasicDataVerticalFoldoutGroupName = BasicDataVerticalGroupName +  "/Base Data";
		private const string BasicDataHorizontalGroup = BasicDataVerticalFoldoutGroupName + "/Cooldown";
		private const string BasicDataCooldownVerticalGroup = BasicDataHorizontalGroup + "/Vertical1";
		private const string BasicDataCostVerticalGroup = BasicDataHorizontalGroup + "/Vertical2";

		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicSkillDataFoldoutGroupName)][HorizontalGroup(SkillDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public GameObject Prefab;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(BasicDataVerticalFoldoutGroupName)]
		[LabelWidth(45)]
		public string Name;

		[VerticalGroup(BasicDataVerticalGroupName)][FoldoutGroup(BasicDataVerticalFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroup, Width = 120)][VerticalGroup(BasicDataCooldownVerticalGroup)]
		[LabelWidth(65)]
		public int Prewarm;

		[VerticalGroup(BasicDataCooldownVerticalGroup)]
		[LabelWidth(65)]
		public int Cooldown;

		[VerticalGroup(BasicDataCooldownVerticalGroup)]
		[LabelWidth(65)]
		public float Duration;

		[HorizontalGroup(BasicDataHorizontalGroup, Width = 120)][VerticalGroup(BasicDataCostVerticalGroup)]
		[HideLabel]
		public UnitResourceType ResourceType;

		[VerticalGroup(BasicDataCostVerticalGroup)]
		[LabelWidth(65)]
		public float Cost;

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
				PrewarmTicks = Prewarm,
				CooldownTicks = Cooldown,
				Duration = Duration,
				ResourceType = ResourceType,
				Cost = Cost,
				Parameters = ConstructParameters(),
				AffectorPrefabs = ConstructAffectorPrefabs()
			};
		}

		private Dictionary<string, TaggedParameter> ConstructParameters()
		{
			var result = new Dictionary<string, TaggedParameter>();
			foreach (var skillParam in SkillParams)
			{
				var parameter = ConstructParameter(skillParam);
				result.Add(skillParam.Name, parameter);
			}

			return result;
		}

		private TaggedParameter ConstructParameter(SkillParam param)
		{
			var tags = new HashSet<string>();
			foreach (var tagGroup in param.Tags)
			{
				if (!string.IsNullOrEmpty(tagGroup.Tag1) && !tags.Contains(tagGroup.Tag1)) tags.Add(tagGroup.Tag1);
				if (!string.IsNullOrEmpty(tagGroup.Tag2) && !tags.Contains(tagGroup.Tag2)) tags.Add(tagGroup.Tag2);
				if (!string.IsNullOrEmpty(tagGroup.Tag3) && !tags.Contains(tagGroup.Tag3)) tags.Add(tagGroup.Tag3);
			}

			var tagsData = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset").TagsData;
			foreach (var tag in tags)
			{
				AddTagAndItsAncestorsToHashset(tag, tags, tagsData);
			}

			var parameter = new TaggedParameter(param.Name, tags.Select(tag => new ParameterTag(tag)));
			return parameter;
		}

		private void AddTagAndItsAncestorsToHashset(string tag, HashSet<string> tags, ValueTagsData tagsData)
		{
			if (string.IsNullOrEmpty(tag)) return;
			if(!tags.Contains(tag)) tags.Add(tag);

			var ancestors = tagsData.Tags.First(tagData => tagData.Name == tag).Ancestors;
			if (ancestors == null) return;

			foreach (var ancestor in ancestors)
			{
				AddTagAndItsAncestorsToHashset(ancestor, tags, tagsData);
			}
		}

		private Dictionary<string, Affector> ConstructAffectorPrefabs()
			=> Affectors.ToDictionary(
				affectorData => affectorData.Name, 
				affectorData => affectorData.Prefab);
	}
}