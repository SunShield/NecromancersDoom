using System.Collections.Generic;
using NDoom.Unity.ScriptableObjects.Data.Named.Battle;
using NDoom.Unity.ScriptableObjects.Data.Named.Effect;
using NDoom.Unity.ScriptableObjects.Data.Named.Skills;
using NDoom.Unity.ScriptableObjects.Data.Named.Unit;
using NDoom.Unity.ScriptableObjects.Data.Single.Tags;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data.Single
{
	[CreateAssetMenu(fileName = "All Data", menuName = "ScriptableObjects/All Data", order = 0)]
	public class AllData : ScriptableObject
	{
		private static AllData _instance;
		public static AllData Instance
		{
			get
			{
				if (_instance == null) _instance = AssetDatabase.LoadAssetAtPath<AllData>(@"Assets/Data/All Data.asset");
				return _instance;
			}
		}

		public List<BattleData> Battles;
		public List<UnitData> Units;
		public List<SkillData> Skills;
		public List<EffectData> Effects;
		public MainDataSo m_mainDataSo;
		public ValueTagsData TagsData;

		public void Add(SerializedScriptableObject obj)
		{
			if(obj is BattleData battleData) Battles.Add(battleData);
			if(obj is UnitData unitData) Units.Add(unitData);
			if(obj is SkillData skillData) Skills.Add(skillData);
			if(obj is EffectData effectData) Effects.Add(effectData);
		}

		public void Remove(SerializedScriptableObject obj)
		{
			if(obj is BattleData battleData) Battles.Remove(battleData);
			if(obj is UnitData unitData) Units.Remove(unitData);
			if(obj is SkillData skillData) Skills.Remove(skillData);
			if(obj is EffectData effectData) Effects.Remove(effectData);
		}
	}
}