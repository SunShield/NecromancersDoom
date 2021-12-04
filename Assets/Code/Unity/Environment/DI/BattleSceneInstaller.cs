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
			
		}

		private void BindUnityClasses()
		{
			Container.Bind<BattleStarter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<BattleScenePreparer>().FromComponentInHierarchy().AsSingle().NonLazy();

			Container.Bind<BattleSpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}