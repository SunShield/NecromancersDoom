using NDoom.Unity.Entities;
using NDoom.Unity.Entities.Initializing;
using NDoom.Unity.Entities.Spawning;
using NDoom.Unity.Entities.Spawning.Args;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public abstract class InjectingGameEntitySpawner
	{
		[Inject] protected DiContainer Container { get; }

		//protected override TGameEntity CreateEntity(TSpawnArgs args) => Container.InstantiatePrefab(GetPrefab(args)).GetComponent<TGameEntity>();
	}
}