using Sirenix.OdinInspector;

namespace NDoom.Unity.EntitySystem.Loadable
{
	public abstract class NamedData : SerializedScriptableObject
	{
		public abstract string DataName { get; }
	}
}