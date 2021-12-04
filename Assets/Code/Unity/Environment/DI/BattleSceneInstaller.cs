using NDoom.Unity.Battles;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
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
			Container.Bind<BattleGraphicalDataStorage>().AsSingle().NonLazy();
			Container.Bind<BattleGraphicalDataConverter>().AsSingle().NonLazy();
		}

		private void BindUnityClasses()
		{
			Container.Bind<BattleStarter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<BattleScenePreparer>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}