using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public class AbstractStructuralDataStorage<TStructuralData> : AbstractDataStorage<TStructuralData>
		where TStructuralData : EntityStructuralData
	{
	}
}