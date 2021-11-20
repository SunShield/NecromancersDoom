using NDoom.Unity.Battles;
using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Battles.Entities.Storaging;
using NDoom.Unity.Environment.SceneManagement.Preparation;
using Zenject;

namespace NDoom.Unity.Environment.DI
{
	public class BattleSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<BattleStarter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<GlobalBattleEntityManager>().AsSingle().NonLazy();
			Container.Bind<BattleSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<BattlefieldSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<UnitSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<TileSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<BattleEntityRegistry>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<BattleScenePreparer>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}