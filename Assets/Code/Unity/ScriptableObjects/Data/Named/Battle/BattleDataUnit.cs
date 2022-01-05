using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Battle
{
	public class BattleDataUnit
	{
		private const string NameVerticalGroupName = "Name";
		private const string PosVerticalGroupName = "Position";

		[VerticalGroup(NameVerticalGroupName)]
		[HideLabel]
		[ReadOnly]
		public string Name;

		[VerticalGroup(PosVerticalGroupName)]
		[HideLabel]
		public UnitPosition Position;
	}
}