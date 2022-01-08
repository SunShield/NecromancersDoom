using System.Security.AccessControl;
using NDoom.Unity.EntitySystem.DataStructure.Data;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Functional
{
	public class UnitFunctionalData : EntityFunctionalData
	{
		public int MaxHealth;
		public ResourceType ResourceType;
		public int StartingResource;
		public int MaxResource;
		public int ResourceRegen;
	}
}