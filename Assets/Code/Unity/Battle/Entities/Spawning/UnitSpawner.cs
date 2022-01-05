using NDoom.Unity.Battle.Entities.Storaging;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class UnitSpawner : ChildEntitySpawner<Unit, UnitSpawnArgs, Tile>
	{
		[SerializeField] private SpriteRenderer _unitGraphicsPrefab;

		[Inject] private UnitGraphicalDataConverter _converter;
		[Inject] private UnitGraphicalDataStorage _graphicalDataStorage;
		[Inject] private UnitFunctionalDataStorage _functionalDataStorage;
		[Inject] private EntityRegistry _entityRegistry;
		protected override string GetEntityName(UnitSpawnArgs args) => $"Unit [{args.Name}]";

		protected override void ProcessEntityPostChildBinding(Unit entity, UnitSpawnArgs args)
		{
			RegisterUnit(entity);
			SetUnitGraphics(entity, args);
			SetUnitPosition(entity, args);
			SetUnitFunctionalData(entity);
		}

		private void RegisterUnit(Unit unit) => _entityRegistry.RegisterUnit(unit);

		private void SetUnitGraphics(Unit entity, UnitSpawnArgs args)
		{
			var data = _graphicalDataStorage[entity.Name];
			var processedData = _converter.Process(data);
			ConstructUnitGraphics(data, processedData);
			entity.SetGraphics(processedData);
			SetUnitGraphicsFlip(entity, args);
		}

		// TODO: refactor this shit with "Converters" later
		private void ConstructUnitGraphics(UnitGraphicalData data, UnitProcessedGraphicalData processedData)
		{
			processedData.GraphicsInstance = Instantiate(_unitGraphicsPrefab);
			processedData.GraphicsInstance.sprite = data.Graphics;
		}

		private void SetUnitGraphicsFlip(Unit unit, UnitSpawnArgs args)
		{
			var side = unit.Tile.Battlefield.Side;
			if (side != Data.Concrete.Positioning.BattlefieldSide.Right) return;

			var scale = unit.transform.localScale;
			unit.transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
		}

		private void SetUnitPosition(Unit entity, UnitSpawnArgs args) => entity.transform.position = args.Ancestor.transform.position;

		private void SetUnitFunctionalData(Unit entity)
		{
			var data = _functionalDataStorage[entity.Name];
			entity.SetFromFunctionalData(data);
		}
	}
}