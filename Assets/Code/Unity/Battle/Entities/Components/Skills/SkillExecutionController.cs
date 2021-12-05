using NDoom.Unity.EntitySystem.Components;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Components.Skills
{
	public class SkillExecutionController : EntityComponent<Skill>
	{
		private float _prewarmTimer;
		private float _cooldownTimer;

		private bool _wasExecuted;
		private bool IsPrewarming => _prewarmTimer > 0f;
		private bool IsCooldowning => _cooldownTimer > 0f;

		protected override void InitializeComponent()
		{
			_prewarmTimer = Parent.Data.Prewarm;
		}

		public override void UpdateManually()
		{
			if (IsPrewarming)
			{
				AdvancePrewarmTimer();
				return;
			}

			if (Parent.Actions.IsExecuting) return;
			if (_wasExecuted)
			{
				SetSkillExecutionEnded();
				StartCooldownTimer();
			}

			AdvanceCooldownTimer();

			if (!Parent.Actions.CanBeExecuted() || IsCooldowning) return;

			ExecuteSkill();
		}

		private void AdvancePrewarmTimer() => _prewarmTimer = Mathf.Max(0f, _prewarmTimer - Time.deltaTime);
		private void StartCooldownTimer() => _cooldownTimer = Parent.Data.Cooldown;
		private void AdvanceCooldownTimer() => _cooldownTimer = Mathf.Max(0f, _cooldownTimer - Time.deltaTime);

		private void ExecuteSkill()
		{
			Parent.Actions.Execute();
			_wasExecuted = true;
		}

		private void SetSkillExecutionEnded() => _wasExecuted = false;
	}
}