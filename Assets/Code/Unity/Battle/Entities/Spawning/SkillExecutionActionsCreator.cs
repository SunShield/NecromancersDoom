using System;
using System.Collections.Generic;
using NDoom.Unity.Battles.Mechanics.Skills.Execution;
using NDoom.Unity.Battles.Mechanics.Skills.Execution.Concrete;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class SkillExecutionActionsCreator
	{
		private readonly Dictionary<string, Func<SkillExecutionActions>> _actionsNameMap =
			new Dictionary<string, Func<SkillExecutionActions>>()
			{
				{ "TestSkill", () => new TestSkillExecutionActions() }
			};

		[Inject] private DiContainer _container;

		public SkillExecutionActions Create(string name)
		{
			var action = _actionsNameMap[name]();
			_container.Inject(action);
			return action;
		}
	}
}