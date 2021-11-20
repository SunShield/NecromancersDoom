using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.Entities
{
	public class GameEntity : ExtendedMonoBehaviour
	{
		private static int _id;
		private static int GetId() => _id++;

		public int Id { get; private set; }

		protected void SetId() => Id = GetId();

		protected sealed override void InitializeInternal()
		{
			SetId();
		}
	}
}