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

		protected override void ProcessEntityPostPositionSet(Tile tile, TileSpawnArgs args)
		{
			var battlefield = args.Ancestor;
			var directionMultiplier = battlefield.Side == BattlefieldSide.Left ? 1 : -1;

			var xShift = battlefield.transform.position.x + -((float)(battlefield.Cols - 1) / 2) * Consts.TileUnitsSize * directionMultiplier;
			var yShift = battlefield.transform.position.y + ((float)(battlefield.Rows - 1) / 2) * Consts.TileUnitsSize;

			var tileX = xShift + tile.Col * Consts.TileUnitsSize * directionMultiplier;
			var tileY = yShift + -tile.Row * Consts.TileUnitsSize;

			tile.transform.localPosition = new Vector2(tileX, tileY);
		}
	}
}