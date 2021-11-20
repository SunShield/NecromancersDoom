using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class TileSpawner
	{
		//[SerializeField] private Tile _prefab;
		
		//protected override Tile GetPrefab(TileSpawnArgs args) => _prefab;
		//protected override void RenameEntity(Tile entity, TileInitArgs args) => entity.name = $"Tile [{args.Row}, {args.Col}]";

		//protected override void PostEntitySpawn(Tile entity, TileInitArgs args)
		//{
		//	SetTileLocalePosition(entity, args.Battlefield);
		//	args.Battlefield.SetTile(args.Row, args.Col, entity);
		//}

		//private void SetTileLocalePosition(Tile entityUnity, Battlefield battlefield)
		//{
		//	var directionMultiplier = battlefield.Side == BattlefieldSide.Left ? 1 : -1;

		//	var xShift = battlefield.transform.position.x + -((float)(battlefield.Cols - 1) / 2) * BattleEntitySpawnConsts.TileUnitsSize * directionMultiplier;
		//	var yShift = battlefield.transform.position.y + ((float)(battlefield.Rows - 1) / 2) * BattleEntitySpawnConsts.TileUnitsSize;

		//	var tileX = xShift + entityUnity.Col * BattleEntitySpawnConsts.TileUnitsSize * directionMultiplier;
		//	var tileY = yShift + -entityUnity.Row * BattleEntitySpawnConsts.TileUnitsSize;

		//	entityUnity.transform.localPosition = new Vector2(tileX, tileY);
		//}

	}
}