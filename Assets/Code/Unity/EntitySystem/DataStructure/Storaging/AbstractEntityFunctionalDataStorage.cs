using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class AbstractFunctionalDataStorage<TFunctionalData> : AbstractDataStorage<TFunctionalData>
		where TFunctionalData : EntityFunctionalData
	{
	}
}