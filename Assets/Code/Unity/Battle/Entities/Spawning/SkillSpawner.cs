using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class SkillSpawner : ChildEntitySpawner<Skill, SkillSpawnArgs, Unit>
	{
		[Inject] private SkillGraphicalDataConverter _converter;
		[Inject] private SkillGraphicalDataStorage _graphicalDataStorage;
		[Inject] private SkillFunctionalDataStorage _functionalDataStorage;

		protected override string GetEntityName(SkillSpawnArgs args) => $"Skill [{args.Name}]";

		protected override void ProcessEntityPostChildBinding(Skill entity, SkillSpawnArgs args)
		{
			SetSkillGraphics(entity);
			SetSkillPosition(entity, args);
			SetSkillFunctionalData(entity);
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

		private void SetSkillFunctionalData(Skill entity)
		{
			var data = _functionalDataStorage[entity.Name];
			entity.SetFromFunctionalData(data);
		}
	}
}