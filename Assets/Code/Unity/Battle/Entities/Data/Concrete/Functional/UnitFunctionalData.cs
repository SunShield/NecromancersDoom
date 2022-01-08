using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit.UResources;
using NDoom.Unity.Battles.Mechanics.Modifiable;
using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Functional
{
	public class UnitFunctionalData : EntityFunctionalData
	{
		public int MaxHealth;

		public UnitResourceType ResourceType;
		public int StartingResource;
		public int MaxResource;
		public int ResourceRegen;

		public UnitMechanicalData ToMechanicalData()
		{
			return new UnitMechanicalData()
			{
				Stats = new MainUnitStats()
				{
					MaxHealth = new ModifiableFloat(MaxHealth),
					CurrentHealth = new ModifiableFloat(MaxHealth)
				},
				Resource = new UnitResource()
				{
					Type = ResourceType,
					Current = StartingResource,
					Max = new ModifiableFloat(MaxResource),
					Regen = new ModifiableFloat(ResourceRegen),
				}
			};
		}
	}
}