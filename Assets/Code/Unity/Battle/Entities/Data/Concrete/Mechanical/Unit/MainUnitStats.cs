using NDoom.Unity.Battles.Mechanics.Modifiable;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit
{
	public class MainUnitStats
	{
		public ModifiableFloat MaxHealth { get; private set; }
		public ModifiableFloat CurrentHealth { get; private set; }
	}
}