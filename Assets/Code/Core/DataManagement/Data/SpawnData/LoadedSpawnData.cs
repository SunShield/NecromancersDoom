using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Core.DataManagement.DataStructure.Spawn
{
	public abstract class LoadedSpawnData<TNamedData>
		where TNamedData : NamedData
	{
		public void FillFrom(TNamedData data)
		{
			FillFromInternal(data);
		}

		protected virtual void FillFromInternal(TNamedData data) {}
	}
}