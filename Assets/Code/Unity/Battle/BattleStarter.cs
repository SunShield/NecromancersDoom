using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.Battles
{
	public class BattleStarter : ExtendedMonoBehaviour
	{
	}

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