using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles
{
	public class BattleStarter : ExtendedMonoBehaviour
	{
		[Inject] private BattleSpawner _battleSpawner;
		[Inject] private BattleStructuralDataStorage _battleStructuralDataStorage;

		public void StartBattle(string battleName)
		{
			var args = new BattleSpawnArgs()
			{
				Name = battleName,
				StructuralData = _battleStructuralDataStorage[battleName]
			};
			_battleSpawner.Spawn(args);
		}
	}
}