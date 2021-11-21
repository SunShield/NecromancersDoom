using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.Interfaces
{
	/// <summary>
	/// Interface for all the entities able to be initialized with different graphics
	/// </summary>
	/// <typeparam name="TGraphicalData"></typeparam>
	public interface IGraphicalEntity<TGraphicalData> : IEntity
		where TGraphicalData : EntityGraphicalData
	{
		void SetGraphics(TGraphicalData graphicalData);
	}
}