using NDoom.Core.Environment.EventSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Environment.Main
{
	public class ExtendedMonoBehaviour : SerializedMonoBehaviour
	{
		[Inject] private Updater _updater;
		[Inject] protected EventBus EventBus { get; }

		public Transform Transform { get; private set; }

		[Inject]
		private void Initialize()
		{
			if (_updater == null) InjectCurrentGo();

			RegisterThisBehaviourForUpdate();
			InitializeComponents();
			InitializeInternal();
		}

		// Здесь происходит кое-что не слишком красивое, что, по идее, должно решить проблемы с тем, что создающиеся динамически объекты
		// не инджектятся зенджектом по умолчанию. По-сути, мы делаем простую проверку на то, заинджекчен ли объект, засчёт хард-депенденси
		// с классом Updater. И если нет - инджектим его сейчас.
		private void InjectCurrentGo()
		{
			ProjectContext.Instance.Container.InjectGameObject(gameObject);
			GetContainerForCurrentScene().InjectGameObject(gameObject);
		}

		private DiContainer GetContainerForCurrentScene()
			=> ProjectContext.Instance.Container.Resolve<SceneContextRegistry>().GetContainerForScene(gameObject.scene);

		private void RegisterThisBehaviourForUpdate() => _updater.RegisterUpdatebleBehaviour(this);

		private void InitializeComponents()
        {
			Transform = transform;
        }

		protected virtual void InitializeInternal() { }
		protected virtual void DestroyInternal() { }
		public virtual void UpdateManually() { }
		public virtual void FixedUpdateManually() { }

		private void OnDestroy() => DestroyInternal();
	}
}