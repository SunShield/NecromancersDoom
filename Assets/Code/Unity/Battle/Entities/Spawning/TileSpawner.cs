using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using UnityEngine;
using Consts = NDoom.Unity.Battles.Entities.Spawning.BattleEntitiesSpawningConsts.Battle;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class TileSpawner : PositionableEntitySpawner<Tile, TileSpawnArgs, Battlefield, TilePositioningData>
	{
		protected override string GetEntityName(TileSpawnArgs args) => $"Tile [{args.Position.Row}, {args.Position.Col}]";

		protected override void ProcessEntityPostChildBinding(Tile entity, TileSpawnArgs args)
		{
			SetTilePosition(entity, args);
		}

		private void SetTilePosition(Tile entity, TileSpawnArgs args)
		{
			var battlefield = args.Ancestor;
			var directionMultiplier = battlefield.Side == BattlefieldSide.Left ? 1 : -1;

			var xShift = -((float)(battlefield.Cols - 1) / 2) * Consts.TileUnitsSize * directionMultiplier;
			var yShift = ((float)(battlefield.Rows - 1) / 2) * Consts.TileUnitsSize;

			var tileX = xShift + entity.Col * Consts.TileUnitsSize * directionMultiplier;
			var tileY = yShift + -entity.Row * Consts.TileUnitsSize;

			entity.transform.localPosition = new Vector2(tileX, tileY);
		}
	}
}