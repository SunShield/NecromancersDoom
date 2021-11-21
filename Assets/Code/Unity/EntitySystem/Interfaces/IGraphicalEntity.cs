using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Interfaces
{
	/// <summary>
	/// Interface for all the entities able to be initialized with different graphics
	/// </summary>
	/// <typeparam name="TGraphicalData"></typeparam>
	public interface IGraphicalEntity<TGraphicalData, TProcessedGraphicalData> : IEntity
		where TGraphicalData : EntityGraphicalData
		where TProcessedGraphicalData : EntityProcessedGraphicalData
	{
		void SetGraphics(TProcessedGraphicalData graphicalData);
	}
}