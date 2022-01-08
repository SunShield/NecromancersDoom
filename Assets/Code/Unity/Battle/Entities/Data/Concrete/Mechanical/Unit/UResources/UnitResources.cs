using NDoom.Unity.Battles.Mechanics.Modifiable;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources
{
	public class UnitResource
	{
		public UnitResourceType Type { get; set; }
		public float Current { get; set; }
		public ModifiableFloat Max { get; set; }
		public ModifiableFloat Regen { get; set; }
	}
}