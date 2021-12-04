using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class UnitSpawner : ChildEntitySpawner<Unit, UnitSpawnArgs, Tile>
	{
		[Inject] private UnitGraphicalDataConverter _converter;
		[Inject] private UnitGraphicalDataStorage _graphicalDataStorage;
		[Inject] private UnitFunctionalDataStorage _functionalDataStorage;

		protected override string GetEntityName(UnitSpawnArgs args) => $"Unit [{args.Name}]";

		protected override void ProcessEntityPostChildBinding(Unit entity, UnitSpawnArgs args)
		{
			SetUnitGraphics(entity);
			SetUnitPosition(entity, args);
			SetUnitFunctionalData(entity);
		}

		private void SetUnitGraphics(Unit entity)
		{
			var data = _graphicalDataStorage[entity.Name];
			var processedData = _converter.Process(data);
			entity.SetGraphics(processedData);
		}

		private void SetUnitPosition(Unit entity, UnitSpawnArgs args)
		{
			entity.transform.position = args.Ancestor.transform.position;
		}

		private void SetUnitFunctionalData(Unit entity)
		{
			var data = _functionalDataStorage[entity.Name];
			entity.SetFromFunctionalData(data);
		}
	}
}