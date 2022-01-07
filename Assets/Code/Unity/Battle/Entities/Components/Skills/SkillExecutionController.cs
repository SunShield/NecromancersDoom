using NDoom.Core.Environment.EventSystem;
using NDoom.Core.Environment.EventSystem.Concrete.Events.Tick;
using NDoom.Core.EventSystem.Concrete.Args;
using NDoom.Unity.EntitySystem.Components;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Components.Skills
{
	public class SkillExecutionController : EntityComponent<Skill>
	{
		[Inject] private EventBus _eventBus;

		private int _prewarmTicks;
		private int _cooldownTicks;

		private bool _wasExecuted;
		private bool IsPrewarming => _prewarmTicks > 0;
		private bool IsCooldowning => _cooldownTicks > 0;

		protected override void InitializeComponent()
		{
			_prewarmTicks = Parent.Data.PrewarmTicks;
			_eventBus.GetEvent<OnPlayerTickEvent>().SubscribeForGlobal(OnTick);
		}

		private void OnTick(PlayerTickArgs args)
		{
			if (args.PlayerSide != Parent.HolderUnit.Tile.Battlefield.Side) return;

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

		private void AdvancePrewarmTimer() => _prewarmTicks -= 1;
		private void StartCooldownTimer() => _cooldownTicks = Parent.Data.CooldownTicks;
		private void AdvanceCooldownTimer() => _cooldownTicks -= 1;

		private void ExecuteSkill()
		{
			Parent.Actions.Execute();
			_wasExecuted = true;
		}

		private void SetSkillExecutionEnded() => _wasExecuted = false;
	}
}