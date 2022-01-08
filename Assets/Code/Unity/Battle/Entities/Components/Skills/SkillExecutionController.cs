using NDoom.Unity.EntitySystem.Components;

namespace NDoom.Unity.Battles.Entities.Components.Skills
{
	public class SkillExecutionController : EntityComponent<Skill>
	{
		private int _prewarmTicks;
		private int _cooldownTicks;

		private bool _wasExecuted;
		private bool IsPrewarming => _prewarmTicks > 0;
		private bool IsCooldowning => _cooldownTicks > 0;

		protected override void InitializeComponent() => _prewarmTicks = Parent.Data.PrewarmTicks;

		protected override void OnTick()
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

			if (!Parent.Actions.CanBeExecuted() || !Parent.CanBePaid() || IsCooldowning) return;

			ExecuteSkill();
		}

		private void AdvancePrewarmTimer() => _prewarmTicks -= 1;
		private void StartCooldownTimer() => _cooldownTicks = Parent.Data.CooldownTicks;
		private void AdvanceCooldownTimer() => _cooldownTicks -= 1;

		private void ExecuteSkill()
		{
			Parent.HolderUnit.PaySkill(Parent);
			Parent.Actions.Execute();
			_wasExecuted = true;
		}

		private void SetSkillExecutionEnded() => _wasExecuted = false;
	}
}