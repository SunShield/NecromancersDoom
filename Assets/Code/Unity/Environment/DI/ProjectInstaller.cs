using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Battles.Entities.Data.Concrete;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Entities.Spawning;
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
			Container.Bind<UnitStructuralDataStorage>().AsSingle().NonLazy();
			Container.Bind<SkillFunctionalDataStorage>().AsSingle().NonLazy();
			Container.Bind<SkillGraphicalDataConverter>().AsSingle().NonLazy();
			Container.Bind<SkillGraphicalDataStorage>().AsSingle().NonLazy();
			Container.Bind<TagsData>().AsSingle().NonLazy();
		}

		private void BindUnityClasses()
		{
			Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<AllDataReferenceHolder>().FromComponentInNewPrefab(_allDataReferenceHolderPrefab).AsSingle().NonLazy();
			Container.Bind<Updater>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<GameSceneManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}