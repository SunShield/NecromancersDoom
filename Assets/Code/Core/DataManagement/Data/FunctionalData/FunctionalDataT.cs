using NDoom.Unity.ScriptableObjects.Data;

namespace NDoom.Core.DataManagement.DataStructure.Functional
{
	public class FunctionalDataT<TNamedData>
		where TNamedData : NamedData
	{
		public string Name { get; private set; }

		public void FillFrom(TNamedData data)
		{
			Name = data.DataName;
			FillFromInternal(data);
		}

		protected virtual void FillFromInternal(TNamedData data) {}
	}
}