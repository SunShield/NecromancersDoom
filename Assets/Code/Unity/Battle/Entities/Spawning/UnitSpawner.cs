using NDoom.Unity.Battles.Entities.Data.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.DataStructure.Storaging.Concrete;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class UnitSpawner : ChildEntitySpawner<Unit, UnitSpawnArgs, Tile>
	{
		[Inject] private UnitGraphicalDataConverter _converter;
		[Inject] private UnitGraphicalDataStorage _storage;

		protected override string GetEntityName(UnitSpawnArgs args) => $"Unit [{args.Name}]";

		protected override void ProcessEntityPostChildBinding(Unit entity, UnitSpawnArgs args)
		{
			SetUnitGraphics(entity);
			SetUnitPosition(entity, args);
		}

		private void SetUnitGraphics(Unit entity)
		{
			var data = _storage[entity.Name];
			var processedData = _converter.Process(data);
			entity.SetGraphics(processedData);
		}

		private void SetUnitPosition(Unit entity, UnitSpawnArgs args)
		{
			entity.transform.position = args.Ancestor.transform.position;
		}
	}
}