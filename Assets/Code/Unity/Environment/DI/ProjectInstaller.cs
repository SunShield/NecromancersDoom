using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Data;
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
			Container.Bind<EventBus>().AsSingle().NonLazy();

			Container.Bind<BattleGraphicalDataStorage>().AsSingle().NonLazy();
			Container.Bind<BattleGraphicalDataConverter>().AsSingle().NonLazy();
			Container.Bind<UnitGraphicalDataStorage>().AsSingle().NonLazy();
			Container.Bind<UnitGraphicalDataConverter>().AsSingle().NonLazy();
			Container.Bind<UnitFunctionalDataStorage>().AsSingle().NonLazy();
			Container.Bind<BattleStructuralDataStorage>().AsSingle().NonLazy();
		}

		private void BindUnityClasses()
		{
			Container.Bind<AllDataReferenceHolder>().FromComponentInNewPrefab(_allDataReferenceHolderPrefab).AsSingle().NonLazy();
			Container.Bind<Updater>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<GameSceneManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}