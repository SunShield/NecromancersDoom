﻿using System;
using NDoom.Unity.EntitySystem.DataStructure.Data;
using NDoom.Unity.EntitySystem.Reflection;

namespace NDoom.Unity.EntitySystem.DataStructure.Storaging
{
	public class FunctionalEntityDataStorage : AbsctractEntityDataStorage<EntityFunctionalData>
	{
		protected override Func<EntityReflectionData, bool> ReflectionDataCheckDelegate
			=> rd => rd.FunctionalDataType == null;
		protected override Func<EntityReflectionData, Type> GetTypeForDataTypeMapDelegate
			=> rd => rd.FunctionalDataType;
	}
}