namespace NDoom.Unity.EntitySystem.DataStructure.Data.Converters
{
	public abstract class GraphicalDataConverter<TGraphicalData, TProcessedGraphicalData>
		where TGraphicalData : EntityGraphicalData
		where TProcessedGraphicalData : EntityProcessedGraphicalData
	{
		public abstract TProcessedGraphicalData Process(TGraphicalData data);
	}
}