using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Concrete
{
	public class Battlefield
	{
		[SerializeField] private Transform _tilesOrigin;

		private Tile[,] _tiles;

		public int Rows { get; private set; }
		public int Cols { get; private set; }
		public BattlefieldSide Side { get; private set; }

		public Tile this[int row, int col] => _tiles[row, col];
	}
}