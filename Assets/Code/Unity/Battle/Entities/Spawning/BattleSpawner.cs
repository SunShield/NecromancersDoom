using NDoom.Unity.Battles.Entities.Data.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.DataStructure.Storaging.Concrete;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattleSpawner : EntitySpawner<Battle, BattleSpawnArgs>
	{
		[Inject] private BattleGraphicalDataStorage _storage;
		[Inject] private BattleGraphicalDataConverter _converter;

		protected override string GetEntityName(BattleSpawnArgs args) => $"Battle [{args.Name}]";

		protected override void ProcessEntityPostCreate(Battle entity, BattleSpawnArgs args)
		{
			var graphicalData = _storage[args.Name];
			var processedData = _converter.Process(graphicalData);
			entity.SetGraphics(processedData);
		}
	}
}