using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattleSpawner
	{
		[SerializeField] private Battle _prefab;

		//protected override Battle GetPrefab(BattleSpawnArgs args) => _prefab;
	}
}