using NDoom.Unity.Battles.Mechanics.Modifiable;

namespace NDoom.Unity.Battle.Environment.Players
{
	public class PlayerTickState
	{
		public ModifiableFloat TickTime { get; private set; } = new ModifiableFloat(PlayerConstants.DefaultTickMs);
		public float PreviousTickTime { get; set; }
		public float ReversedRelativeTick => PlayerConstants.DefaultTickMs / PreviousTickTime;
	}
}