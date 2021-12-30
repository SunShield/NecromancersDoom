using System.Collections;
using System.Collections.Generic;
using NDoom.Unity.Battle.Mechanics.Skills.Affection;
using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Entities;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles.Mechanics.Skills.Execution
{
	/// <summary>
	/// This is an internal class for storing "What exactly skill does".
	/// Those are referenced by skill. So we can use general skill prefab
	/// and compose skill from separate graphics and execution actions.
	/// </summary>
	public abstract class SkillExecutionActions
	{
		[Inject] private CoroutineRunner _coroutineRunner;
		[Inject] protected AffectorSpawner AffectorSpawner { get; }
		public Skill OwnerSkill { get; private set; }

		public bool IsExecuting { get; private set; }
		public IReadOnlyDictionary<string, TaggedParameter> Parameters => OwnerSkill.Data.Parameters;
		public IReadOnlyDictionary<string, Affector> AffectorPrefabs => OwnerSkill.Data.AffectorPrefabs;

		// TODO: pass params here
		public void Initialize(Skill skill) => OwnerSkill = skill;

		/// <summary>
		/// This method can be used to prevent execution of skill if some battlefield conditions are not met
		/// For example, skill can target only units of a specific type and skill won't be activated if there are no such units
		/// Maybe later this should be changed to a specific ExecutionRule set.
		/// </summary>
		/// <returns></returns>
		public virtual bool CanBeExecuted() => true;

		public void Execute()
		{
			_coroutineRunner.DoStartCoroutine(ExecuteDynamically());
		}

		private IEnumerator ExecuteDynamically()
		{
			IsExecuting = true;
			yield return ExecuteInternal();
			IsExecuting = false;
		}

		protected abstract IEnumerator ExecuteInternal();

		public void StopExecution()
		{
			IsExecuting = false;
			_coroutineRunner.InterruptCoroutine(ExecuteDynamically());
		}
	}
}