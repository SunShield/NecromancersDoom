using NDoom.Unity.Battle.Entities.Storaging;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattleSpawner : EntitySpawner<BattleU, BattleSpawnArgs>
	{
		[Inject] private BattleGraphicalDataStorage _storage;
		[Inject] private BattleGraphicalDataConverter _converter;
		[Inject] private EntityRegistry _entityRegistry;

		protected override string GetEntityName(BattleSpawnArgs args) => $"Battle [{args.Name}]";

		protected override void ProcessEntityPostCreate(BattleU entity, BattleSpawnArgs args)
		{
			RegisterEntity(entity);
			SetBattleGraphics(entity, args);
		}

		private void SetBattleGraphics(BattleU entity, BattleSpawnArgs args)
        {
			var graphicalData = _storage[args.Name];
			var processedData = _converter.Process(graphicalData);
			entity.SetGraphics(processedData);
		}

		private void RegisterEntity(BattleU battle) => _entityRegistry.RegisterBattle(battle);
	}
}