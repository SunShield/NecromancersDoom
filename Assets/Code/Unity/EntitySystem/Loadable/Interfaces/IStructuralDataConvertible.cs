using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Loadable.Interfaces
{
	public interface IStructuralDataConvertible<TStructuralData>
		where TStructuralData : EntityStructuralData
	{
		public TStructuralData ToStructuralData();
	}
}