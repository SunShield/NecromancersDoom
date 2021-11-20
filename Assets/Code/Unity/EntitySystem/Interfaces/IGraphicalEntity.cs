namespace NDoom.Unity.EntitySystem.Interfaces
{
	/// <summary>
	/// Interface for all the entities able to be initialized with different graphics
	/// </summary>
	/// <typeparam name="TGraphicalData"></typeparam>
	public interface IGraphicalEntity<TGraphicalData> : IEntity
	{
		void SetGraphics(TGraphicalData graphicalData);
	}
}