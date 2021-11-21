using NDoom.Unity.EntitySystem.Spawning;
using NDoom.Unity.Environment.Initialization;
using Zenject;

namespace NDoom.Unity.Environment.DI
{
	public class LoadingSceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<AppInitializer>().FromComponentInHierarchy().AsSingle().NonLazy();
		}
	}
}