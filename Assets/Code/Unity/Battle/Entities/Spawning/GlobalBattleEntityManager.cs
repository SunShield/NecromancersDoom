using System.Collections.Generic;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Core.DataManagement.Storaging;
using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Battles.Entities.Storaging;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class GlobalBattleEntityManager
	{
		[Inject] private BattleSpawner _battleSpawner;
		[Inject] private BattlefieldSpawner _battlefieldSpawner;
		[Inject] private TileSpawner _tileSpawner;
		[Inject] private UnitSpawner _unitSpawner;
		[Inject] private FunctionalDataStorage _functionalDataStorage;
		[Inject] private LoadedSpawnDataStorage _loadedSpawnDataStorage;

		[Inject] private BattleEntityRegistry _registry;

		//public void FullySpawnBattle(BattleLoadedSpawnData battleLoadedData)
		//{
		//	var battleSpawnArgs = new BattleSpawnArgs();
		//	battleSpawnArgs.GetDataFromSpawnData(battleLoadedData);
		//	var battle = SpawnBattle(battleSpawnArgs);
		//	//_registry.AddEntity(battle);
		//	SpawnUnits(battleLoadedData.DefaultUnits);
		//}

		//private Battle SpawnBattle(BattleSpawnArgs spawnArgs)
		//{
		//	var battle = _battleSpawner.Spawn(spawnArgs);
		//	SpawnBattlefields(spawnArgs, battle);
		//	return battle;
		//}

		//private void SpawnBattlefields(BattleSpawnArgs spawnArgs, Battle battle)
		//{
		//	var leftBattlefield = SpawnBattlefield(BattlefieldSpawnArgs.FromBattleSpawnArgs(spawnArgs, BattlefieldSide.Left, battle));
		//	var rightBattlefield = SpawnBattlefield(BattlefieldSpawnArgs.FromBattleSpawnArgs(spawnArgs, BattlefieldSide.Right, battle));
		//	battle.SetBattlefield(leftBattlefield);
		//	battle.SetBattlefield(rightBattlefield);
		//}

		//private Battlefield SpawnBattlefield(BattlefieldSpawnArgs spawnArgs)
		//{
		//	var battlefield = _battlefieldSpawner.Spawn(spawnArgs);
		//	_registry.AddEntity(battlefield);
		//	SpawnTiles(spawnArgs, battlefield);

		//	return battlefield;
		//}

		//private void SpawnTiles(BattlefieldSpawnArgs spawnArgs, Battlefield battlefield)
		//{
		//	for (int y = 0; y < spawnArgs.Rows; y++)
		//	{
		//		for (int x = 0; x < spawnArgs.Cols; x++)
		//		{
		//			var tile = SpawnTile(new TileSpawnArgs(y, x, battlefield));
		//			_registry.AddEntity(tile);
		//			battlefield.SetTile(y, x, tile);
		//		}
		//	}
		//}

		//private Tile SpawnTile(TileSpawnArgs spawnArgs)
		//{
		//	return _tileSpawner.Spawn(spawnArgs);
		//}

		//private void SpawnUnits(List<(string unitName, BattlefieldSide side, int row, int col)> units)
		//{
		//	foreach (var unit in units)
		//	{
		//		var tile = _registry.Battle[unit.side][unit.row, unit.col];
		//		var spawnData = _loadedSpawnDataStorage.UnitDatas[unit.unitName];
		//		var functionalData = _functionalDataStorage.UnitDatas[unit.unitName];
		//		var newUnit = SpawnUnit(new UnitSpawnArgs(tile, spawnData, functionalData));
		//		tile.SetUnit(newUnit);
		//	}
		//}

		//public Unit SpawnUnit(UnitSpawnArgs spawnArgs)
		//{
		//	return _unitSpawner.Spawn(spawnArgs);
		//}

		//public Unit SpawnUnit(string unitName, BattlefieldSide side, int row, int col)
		//{
		//	var tile = _registry.Battle[side][row, col];
		//	var spawnData = _loadedSpawnDataStorage.UnitDatas[unitName];
		//	var functionalData = _functionalDataStorage.UnitDatas[unitName];
		//	return SpawnUnit(new UnitSpawnArgs(tile, spawnData, functionalData));
		//}
	}
}