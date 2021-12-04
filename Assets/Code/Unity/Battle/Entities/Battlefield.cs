using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Battlefield 
		: Entity, 
		  IPositionableEntity<BattlefieldPositioningData, Battle, Battlefield>, 
		  IAncestorEntity<Tile, Battlefield>
	{
		[SerializeField] private Transform _tilesOrigin;
		private Tile[,] _tiles;

		public Battle Battle { get; private set; }
		public BattlefieldSide Side { get; private set; }
		public int Rows { get; private set; }
		public int Cols { get; private set; }

		public void SetPosition(BattlefieldPositioningData data) => Side = data.Side;
		public void BindToAncestor(Battle ancestor) => Battle = ancestor;

		public void SetSize(int rows, int cols)
		{
			Rows = rows;
			Cols = cols;
			InitTiles();
		}

		private void InitTiles() => _tiles = new Tile[Rows, Cols];

		public void AddChild(Tile tile)
		{
			_tiles[tile.Row, tile.Col] = tile;
			tile.transform.parent = _tilesOrigin;
		}

		public void RemoveChild(Tile tile) => _tiles[tile.Row, tile.Col] = null;
	}
}