using System;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources;
using NDoom.Unity.EntitySystem.Components;

namespace NDoom.Unity.Battles.Entities.Components.Units
{
	public class UnitResourceRegenerationController : EntityComponent<Unit>
	{
		private const int TicksBetweenRegen = 5;
		private const float MinResourceAmount = 0f;

		private int _regenTimer;
		private bool IsTicking => _regenTimer != 0;
		private UnitResource Resource => Parent.Data.Resource;
		private bool UnitHasMaxResource => Resource.Current == Resource.Max.FinalValue;
		private float MaxAmount => Resource.Max.FinalValue;
		private float RegenAmount => Resource.Regen.FinalValue;

		protected override void OnTick()
		{
			if (!IsTicking)
			{
				StartTimer();
				return;
			}

			AdvanceTimer();
			if(!IsTicking) RegenUnitResource();
		}

		private void StartTimer() => _regenTimer = TicksBetweenRegen;
		private void AdvanceTimer() => _regenTimer -= 1;

		private void RegenUnitResource()
		{
			if (UnitHasMaxResource) return;

			Resource.Current = Math.Clamp(Resource.Current + RegenAmount, MinResourceAmount, MaxAmount);
		}
	}
}