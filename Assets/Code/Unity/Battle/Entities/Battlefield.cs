using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Functional;
using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;

namespace NDoom.Unity.Battles.Entities
{
	public class Battlefield 
		: Entity, IPositionableEntity<BattlefieldPositioningData, Battle, Battlefield>, 
			IAncestorEntity<Tile, Battlefield>, IFunctionalEntity<BattlefieldFunctionalData>
	{
		private Tile[,] _tiles;

		public Battle Battle { get; private set; }
		public BattlefieldSide Side { get; private set; }
		public int Rows { get; private set; }
		public int Cols { get; private set; }

		protected override void InitializeEntity() {}

		public void SetPosition(BattlefieldPositioningData data) => Side = data.Side;
		public void BindToAncestor(Battle battle) => Battle = battle;

		public void SetFromFunctionalData(BattlefieldFunctionalData functionalData)
		{
			Rows = functionalData.Rows;
			Cols = functionalData.Cols;
			InitTiles();
		}

		private void InitTiles() => _tiles = new Tile[Rows, Cols];
		public void AddChild(Tile tile) => _tiles[tile.Row, tile.Col] = tile;
		public void RemoveChild(Tile tile) => _tiles[tile.Row, tile.Col] = null;
	}
}