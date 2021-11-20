using Sirenix.OdinInspector;
using Zenject;

namespace NDoom.Unity.Environment.Main
{
	public class ExtendedMonoBehaviour : SerializedMonoBehaviour
	{
		[Inject] private Updater _updater;

		[Inject]
		private void Initialize()
		{
			if (_updater == null) InjectCurrentGo();

			RegisterThisBehaviourForUpdate();
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

		protected virtual void InitializeInternal() { }
		protected virtual void DestroyInternal() { }
		public virtual void UpdateManually() { }

		private void OnDestroy() => DestroyInternal();
	}
}