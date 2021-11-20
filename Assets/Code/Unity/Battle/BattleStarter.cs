using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Core.DataManagement.Storaging;
using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles
{
	public class BattleStarter : ExtendedMonoBehaviour
	{
		[Inject] private GlobalBattleEntityManager _battleEntityManager;
		[Inject] private LoadedSpawnDataStorage _storage;

		public void StartBattle(string battleName)
		{
			var battleSpawnData = _storage.BattleDatas[battleName];
			SpawnBattle(battleSpawnData);
		}

		private void SpawnBattle(BattleLoadedSpawnData battleLoadedData)
		{
			//_battleEntityManager.FullySpawnBattle(battleLoadedData);
		}
	}
}