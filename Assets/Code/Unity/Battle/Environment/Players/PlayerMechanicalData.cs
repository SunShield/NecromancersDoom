using NDoom.Unity.Battles.Mechanics.Modifiable;

namespace NDoom.Unity.Battle.Environment.Players
{
	public class PlayerMechanicalData
	{
		public ModifiableFloat TickTime { get; private set; } = new ModifiableFloat(PlayerConstants.DefaultTickMs);
	}
}
