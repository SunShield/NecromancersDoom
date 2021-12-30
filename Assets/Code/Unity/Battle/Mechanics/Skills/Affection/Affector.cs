using NDoom.Unity.Battle.Affection;
using NDoom.Unity.Battles.Mechanics.Skills.Execution;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;

namespace NDoom.Unity.Battles.Affection
{
	/// <summary>
	/// Special entity existing mainly to translate some affections on collision basis.
	/// A bullet is an affector, and some kind of bullet-consuming forcefield is also an affector.
	/// Affectors interact with units on battlefield, and sometimes with each other.
	/// </summary>
	public class Affector : ExtendedMonoBehaviour
	{
		public SkillExecutionActions SkillActions { get; private set; }
		private AffectorBehaviour _behaviour;

		public IReadOnlyDictionary<string, TaggedParameter> Parameters { get; private set; }
		public IReadOnlyDictionary<string, Affector> AffectorPrefabs => SkillActions.AffectorPrefabs;

		public void Initialize(SkillExecutionActions actions)
        {
			SkillActions = actions;
			Parameters = new Dictionary<string, TaggedParameter>(actions.Parameters);
			GatherBehaviours();
		}

		private void GatherBehaviours()
        {
			_behaviour = GetComponent<AffectorBehaviour>();
			_behaviour.Initialize(this);
        }
	}
}