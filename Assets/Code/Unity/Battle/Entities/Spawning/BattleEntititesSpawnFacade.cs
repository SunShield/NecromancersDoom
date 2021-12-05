﻿using System;
using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattleEntititesSpawnFacade
	{
		[Inject] private BattleStructuralDataStorage _battleStructuralDataStorage;

		[Inject] private BattleSpawner _battleSpawner;
		[Inject] private BattlefieldSpawner _battlefieldSpawner;
		[Inject] private TileSpawner _tileSpawner;
		[Inject] private UnitSpawner _unitSpawner;

		public void SpawnBattle(string battleName)
		{
			var args = CreateBattleSpawnArgs(battleName);
			var battle = _battleSpawner.Spawn(args);
			var structureData = _battleStructuralDataStorage[battleName];
			SpawnBattlefields(battle, structureData);
			SpawnUnitsForBattle(battle, structureData);
		}

		private BattleSpawnArgs CreateBattleSpawnArgs(string battleName)
			=> new BattleSpawnArgs() { Name = battleName, };

		private void SpawnBattlefields(Battle battle, BattleStructuralData structuralData)
		{
			foreach (var side in Enum.GetValues(typeof(BattlefieldSide)).Cast<BattlefieldSide>())
			{
				var sideData = structuralData.BattlefieldDatas[side];
				SpawnBattlefield(battle, side, sideData.battlefieldSize, sideData.battlefieldOffset);
			}
		}

		private void SpawnBattlefield(Battle battle, BattlefieldSide side, Vector2Int size, Vector2 offset)
		{
			var args = CreateBattlefieldSpawnArgs(battle, side, size, offset);
			var battlefield = _battlefieldSpawner.Spawn(args);
			SpawnTiles(battlefield);
		}

		private BattlefieldSpawnArgs CreateBattlefieldSpawnArgs(Battle battle, BattlefieldSide side, Vector2Int size, Vector2 offset)
		{
			return new BattlefieldSpawnArgs()
			{
				Ancestor = battle,
				Position = new BattlefieldPositioningData() { Side = side },
				Rows = size.x,
				Cols = size.y,
				Offset = offset
			};
		}

		private void SpawnTiles(Battlefield battlefield)
		{
			for (int y = 0; y < battlefield.Rows; y++)
			{
				for (int x = 0; x < battlefield.Cols; x++)
				{
					SpawnTile(battlefield, y, x);
				}
			}
		}

		private void SpawnTile(Battlefield battlefield, int row, int col)
		{
			var args = CreateTileSpawnArgs(battlefield, row, col);
			var tile = _tileSpawner.Spawn(args);
		}

		private TileSpawnArgs CreateTileSpawnArgs(Battlefield battlefield, int row, int col)
		{
			return new TileSpawnArgs()
			{
				Ancestor = battlefield,
				Position = new TilePositioningData() { Row = row, Col = col },
				Name = "Tile"
			};
		}

		private void SpawnUnitsForBattle(Battle battle, BattleStructuralData structuralData)
		{
			foreach (var unitData in structuralData.UnitDatas)
			{
				var tile = battle.Battlefields[unitData.side][unitData.row, unitData.col];
				var args = CreateUnitSpawnArgs(unitData.unitName, tile);
				var unit = _unitSpawner.Spawn(args);
			}
		}

		// TODO: implement when Registry will be reimplemented
		//public Unit SpawnUnit(string unitName, BattlefieldSide size, int row, int col)
		//{
		//	var tile = battle.Battlefields[unitData.side][unitData.row, unitData.col];
		//}

		private UnitSpawnArgs CreateUnitSpawnArgs(string unitName, Tile tile)
		{
			return new UnitSpawnArgs()
			{
				Name = unitName,
				Ancestor = tile
			};
		}
	}
}