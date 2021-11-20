using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Battle
{
	public struct UnitPosition
	{
		private const string MainGroupName = "Main";

		[HorizontalGroup(MainGroupName)]
		[LabelWidth(10)]
		public int Y;

		[HorizontalGroup(MainGroupName)]
		[LabelWidth(10)]
		public int X;
	}
}