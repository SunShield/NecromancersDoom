using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battles
{
	public class BattleStarter : ExtendedMonoBehaviour
	{
		[Inject] private BattleEntititesSpawnFacade _spawnFacade;

		public void StartBattle(string battleName)
		{
			_spawnFacade.SpawnBattle(battleName);
		}
	}
}