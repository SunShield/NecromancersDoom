using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Loadable.Interfaces
{
	public interface IGraphicalDataConvertible<TGraphicalData>
		where TGraphicalData : EntityGraphicalData
	{
		public TGraphicalData ToGraphicalData();
	}
}