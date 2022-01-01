using NDoom.Unity.Battle.Environment;
using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles
{
	public class BattleStarter : ExtendedMonoBehaviour
	{
		[Inject] private BattleEnvironment _environment;
		[Inject] private BattleEntititesSpawnFacade _spawnFacade;

		public void StartBattle(string battleName)
		{
			_environment.Initialize();
			_spawnFacade.SpawnBattle(battleName);
		}
	}
}