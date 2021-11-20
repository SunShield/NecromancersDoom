using System.Collections.Generic;
using NDoom.Unity.ScriptableObjects.Data.Battle;
using NDoom.Unity.ScriptableObjects.Data.Effect;
using NDoom.Unity.ScriptableObjects.Data.Skills;
using NDoom.Unity.ScriptableObjects.Data.Unit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.ScriptableObjects.Data
{
	[CreateAssetMenu(fileName = "All Data", menuName = "ScriptableObjects/All Data", order = 0)]
	public class AllData : ScriptableObject
	{
		public List<BattleData> Battles;
		public List<UnitData> Units;
		public List<SkillData> Skills;
		public List<EffectData> Effects;

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