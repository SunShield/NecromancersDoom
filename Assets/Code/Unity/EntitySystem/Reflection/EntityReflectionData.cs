using System;

namespace NDoom.Unity.EntitySystem.Reflection
{
	public class EntityReflectionData
	{
		public Type EntityType { get; set; }

		public Type GraphicalDataType { get; set; }
		public Delegate GraphicalDataSetDelegate { get; set; }

		public Type FunctionalDataType { get; set; }
		public Delegate FunctionalDataSetDelegate { get; set; }
	}
}