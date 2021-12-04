using NDoom.Unity.Battles.Entities.Data.Positioning;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Battle
{
	public class BattleDataUnit
	{
		private const string NameVerticalGroupName = "Name";
		private const string SideVerticalGroupName ="Side";
		private const string PosVerticalGroupName = "Position";

		[VerticalGroup(NameVerticalGroupName)]
		[HideLabel]
		public string Name;

		[VerticalGroup(SideVerticalGroupName)]
		[HideLabel]
		public BattlefieldSide Side;

		[VerticalGroup(PosVerticalGroupName)]
		[HideLabel]
		public UnitPosition Position;
	}
}