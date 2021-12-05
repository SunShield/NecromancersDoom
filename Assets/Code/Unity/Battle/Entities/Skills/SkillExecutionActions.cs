using System.Collections;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Skills
{
	/// <summary>
	/// This is an internal class for storing "What exactly skill does".
	/// Those are referenced by skill. So we can use general skill prefab
	/// and compose skill from separate graphics and execution actions.
	/// </summary>
	public abstract class SkillExecutionActions
	{
		[Inject] private CoroutineRunner _coroutineRunner;

		public bool IsExecuting { get; private set; }

		// TODO: pass params here
		public void Initialize() { }

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