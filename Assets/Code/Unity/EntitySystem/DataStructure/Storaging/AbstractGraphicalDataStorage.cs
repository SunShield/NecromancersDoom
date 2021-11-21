using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class AbstractGraphicalDataStorage<TGraphicalData> : AbstractDataStorage<TGraphicalData>
		where TGraphicalData : EntityGraphicalData
	{
	}
}