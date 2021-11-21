using System;
using NDoom.Unity.EntitySystem.DataStructure.Data;
using NDoom.Unity.EntitySystem.Reflection;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public class GraphicalEntityDataStorage : AbsctractEntityDataStorage<EntityGraphicalData>
	{
		protected override Func<EntityReflectionData, bool> ReflectionDataCheckDelegate
			=> rd => rd.GraphicalDataType == null;
		protected override Func<EntityReflectionData, Type> GetTypeForDataTypeMapDelegate
			=> rd => rd.GraphicalDataType;
	}
}