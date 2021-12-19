using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class SkillSpawner : ChildEntitySpawner<Skill, SkillSpawnArgs, Unit>
	{
		[Inject] private SkillGraphicalDataConverter _converter;
		[Inject] private SkillGraphicalDataStorage _graphicalDataStorage;
		[Inject] private SkillFunctionalDataStorage _functionalDataStorage;

		[Inject] private SkillExecutionActionsCreator _actionsCreator;

		protected override string GetEntityName(SkillSpawnArgs args) => $"Skill [{args.Name}]";

		protected override void ProcessEntityPostChildBinding(Skill entity, SkillSpawnArgs args)
		{
			SetEntityData(entity, args);
			SetSkillExecutionActions(entity);
		}

		private void SetEntityData(Skill entity, SkillSpawnArgs args)
		{
			SetSkillGraphics(entity);
			SetSkillPosition(entity, args);
			SetSkillFunctionalData(entity, args);
		}

		private void SetSkillGraphics(Skill entity)
		{
			var data = _graphicalDataStorage[entity.Name];
			var processedData = _converter.Process(data);
			entity.SetGraphics(processedData);
		}

		private void SetSkillPosition(Skill entity, SkillSpawnArgs args)
		{
			entity.transform.position = args.Ancestor.transform.position;
		}

		private void SetSkillFunctionalData(Skill entity, SkillSpawnArgs args)
		{
			var data = _functionalDataStorage[entity.Name];
			foreach (var paramValue in args.ParamValues.Keys)
			{
				var overridenParam = new TaggedParameter(data.Parameters[paramValue])
				{
					InnerValue = args.ParamValues[paramValue]
				};
				data.Parameters[paramValue] = overridenParam;
			}
			entity.SetFromFunctionalData(data);
		}

		private void SetSkillExecutionActions(Skill entity)
		{
			var actions = _actionsCreator.Create(entity.Name);
			entity.SetExecutionActions(actions);
			actions.Initialize(entity);
		}
	}
}