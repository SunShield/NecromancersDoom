using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.Battles.Entities.Data.Structural;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;

namespace NDoom.Unity.Battles.Entities
{
	public class Battlefield 
		: Entity, 
		  IPositionableEntity<BattlefieldPositioningData, Battle, Battlefield>, 
		  IAncestorEntity<Tile, Battlefield>, 
		  IStructurableEntity<BattlefieldStructuralData>
	{
		private Tile[,] _tiles;

		public Battle Battle { get; private set; }
		public BattlefieldSide Side { get; private set; }
		public int Rows { get; private set; }
		public int Cols { get; private set; }

		public void SetPosition(BattlefieldPositioningData data) => Side = data.Side;
		public void BindToAncestor(Battle battle) => Battle = battle;

		public void SetSize(int rows, int cols)
		{
			Rows = rows;
			Cols = cols;
			InitTiles();
		}

		private void InitTiles() => _tiles = new Tile[Rows, Cols];
		public void AddChild(Tile tile) => _tiles[tile.Row, tile.Col] = tile;
		public void RemoveChild(Tile tile) => _tiles[tile.Row, tile.Col] = null;
	}
}