using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data
{
	public abstract class NamedData : SerializedScriptableObject
	{
		public abstract string DataName { get; }
	}
}