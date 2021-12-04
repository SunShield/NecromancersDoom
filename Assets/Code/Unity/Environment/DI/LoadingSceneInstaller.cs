using NDoom.Unity.Data;
using NDoom.Unity.Environment.Initialization;
using Zenject;

namespace NDoom.Unity.Environment.DI
{
	public class LoadingSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<AllDataLoader>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<AppInitializer>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}