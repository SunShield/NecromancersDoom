using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public abstract class AbstractEntityFunctionalDataStorage<TFunctionalData> : AbstractDataStorage<TFunctionalData>
		where TFunctionalData : EntityFunctionalData
	{
	}
}