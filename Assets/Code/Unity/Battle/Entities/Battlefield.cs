using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using NDoom.Unity.Battle.Environment.Players;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Battlefield 
		: Entity, 
		  IPositionableEntity<BattlefieldPositioningData, BattleU, Battlefield>, 
		  IAncestorEntity<Tile, Battlefield>
	{
		[SerializeField] private Transform _tilesOrigin;
		[SerializeField] [ReadOnly] private List<List<Tile>> _tiles = new List<List<Tile>>();

		public BattleU Battle { get; private set; }
		public BattlePlayer OwningPlayer { get; private set; }
		public BattlefieldSide Side { get; private set; }
		public int Rows { get; private set; }
		public int Cols { get; private set; }
		public List<List<Tile>> Tiles => _tiles;

		public void SetPlayer(BattlePlayer player) => OwningPlayer = player;
		public void SetPosition(BattlefieldPositioningData data) => Side = data.Side;
		public void BindToAncestor(BattleU ancestor) => Battle = ancestor;

		public void SetSize(int rows, int cols)
		{
			Rows = rows;
			Cols = cols;
			InitTiles();
		}

		private void InitTiles() 
		{
			for(int y = 0; y < Rows; y++)
				_tiles.Add(new List<Tile>());

			for (int y = 0; y < Rows; y++)
				for (int x = 0; x < Cols; x++)
					_tiles[y].Add(null);
		}

		public void AddChild(Tile tile)
		{
			_tiles[tile.Row][tile.Col] = tile;
			tile.transform.parent = _tilesOrigin;
		}

		public void RemoveChild(Tile tile) => _tiles[tile.Row][tile.Col] = null;

		public Tile this[int row, int col] => _tiles[row][col];
	}
}