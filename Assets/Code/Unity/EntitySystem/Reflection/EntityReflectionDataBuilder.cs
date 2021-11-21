using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NDoom.Unity.EntitySystem.Reflection
{
	public class EntityReflectionDataBuilder
	{
		public Dictionary<Type, EntityReflectionData> BuildForAllEntities()
		{
			var entityType = typeof(Entity);
			var entityTypes = Assembly.GetAssembly(entityType).GetTypes()
				.Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(entityType))
				.ToList();
			var reflectionDatas = new Dictionary<Type, EntityReflectionData>();

			foreach (var type in entityTypes)
			{
				var data = BuildFromEntity(type);
				reflectionDatas.Add(type, data);
			}

			return reflectionDatas;
		}

		public EntityReflectionData BuildFromEntity(Type entityType)
		{
			var graphicalDataType = GetGraphicalData(entityType, out var graphicalDelegate);
			var functionalDataType = GetFunctionalData(entityType, out var functionalDelegate);
			var data = new EntityReflectionData
			{
				EntityType = entityType,
				GraphicalDataType = graphicalDataType,
				GraphicalDataSetDelegate = graphicalDelegate,
				FunctionalDataType = functionalDataType,
				FunctionalDataSetDelegate = functionalDelegate
			};

			return data;
		}

		private static Type GetGraphicalData(Type entityType, out Delegate graphicalDelegate)
		{
			graphicalDelegate = null;
			var graphicalInterface = entityType.GetInterface(EntityReflectionConsts.Graphical.GraphicalInterfaceName);
			if (graphicalInterface == null) return null;

			var graphicalSetMethod = graphicalInterface.GetMethod(EntityReflectionConsts.Graphical.GraphicalMethodName);
			var graphicalDataType = graphicalInterface.GetGenericArguments()[EntityReflectionConsts.Graphical.GraphicalDataGenericArgIndex];
			var processedGraphicalDataType = graphicalInterface.GetGenericArguments()[EntityReflectionConsts.Graphical.ProcessedGraphicalDataGenericArgIndex];
			var graphicalDelegateType = typeof(Action<,>).MakeGenericType(entityType, processedGraphicalDataType);
			graphicalDelegate = graphicalSetMethod.CreateDelegate(graphicalDelegateType);
			return graphicalDataType;
		}

		private static Type GetFunctionalData(Type entityType, out Delegate functionalDelegate)
		{
			functionalDelegate = null;
			var functionalInterface = entityType.GetInterface(EntityReflectionConsts.Functional.FunctionalInterfaceName);
			if (functionalInterface == null) return null;

			var functionalSetMethod = functionalInterface.GetMethod(EntityReflectionConsts.Functional.FunctionalMethodName);
			var functionalDataType = functionalInterface.GetGenericArguments()[0];
			var functionalDelegateType = typeof(Action<,>).MakeGenericType(entityType, functionalDataType);
			functionalDelegate = functionalSetMethod.CreateDelegate(functionalDelegateType);
			return functionalDataType;
		}
	}
}