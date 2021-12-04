using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Loadable.Interfaces
{
	public interface IFunctionalDataConvertible<TFunctionalData>
		where TFunctionalData : EntityFunctionalData
	{
		public TFunctionalData ToFunctionalData();
	}
}