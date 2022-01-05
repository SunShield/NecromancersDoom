using NDoom.Unity.Battle.Entities.Storaging;
using NDoom.Unity.Battle.Environment;
using NDoom.Unity.Battle.Environment.Players.Cards;
using NDoom.Unity.Battle.Mechanics.Skills.Affection;
using NDoom.Unity.Battles;
using NDoom.Unity.Battles.Entities.Spawning;
using NDoom.Unity.Environment.SceneManagement.Preparation;
using Zenject;

namespace NDoom.Unity.Environment.DI
{
	public class BattleSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindNonUnityClasses();
			BindUnityClasses();
		}

		private void BindNonUnityClasses()
		{
			Container.Bind<EntityRegistry>().AsSingle().NonLazy();
			Container.Bind<SkillExecutionActionsCreator>().AsSingle().NonLazy();
			Container.Bind<BattleEntititesSpawnFacade>().AsSingle().NonLazy();
		}

		private void BindUnityClasses()
		{
			Container.Bind<BattleStarter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<BattleEnvironment>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<BattleScenePreparer>().FromComponentInHierarchy().AsSingle().NonLazy();

			Container.Bind<BattleSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<BattlefieldSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<TileSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<UnitSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<SkillSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
			Container.Bind<AffectorSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();

			Container.Bind<PlayerCardPlayer>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}