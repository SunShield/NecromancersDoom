using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Data;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.DataStructure.Storaging;
using NDoom.Unity.EntitySystem.Reflection;
using NDoom.Unity.Environment.Main;
using NDoom.Unity.Environment.SceneManagement.Switching;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Environment.DI
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] private AllDataReferenceHolder _allDataReferenceHolderPrefab;

		public override void InstallBindings()
		{
			BindNonUnityClasses();
			BindUnityClasses();
		}

		private void BindNonUnityClasses()
		{
			Container.Bind<EntitySystemMain>().AsSingle().NonLazy();
			Container.Bind<EntityReflectionDataStorage>().AsSingle().NonLazy();
			Container.Bind<EntityReflectionDataBuilder>().AsSingle().NonLazy();
			Container.Bind<GraphicalEntityDataStorage>().AsSingle().NonLazy();
			Container.Bind<FunctionalEntityDataStorage>().AsSingle().NonLazy();
			Container.Bind<EventBus>().AsSingle().NonLazy();
		}

		private void BindUnityClasses()
		{
			Container.Bind<AllDataReferenceHolder>().FromComponentInNewPrefab(_allDataReferenceHolderPrefab).AsSingle().NonLazy();
			Container.Bind<Updater>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<GameSceneManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}