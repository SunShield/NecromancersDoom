namespace NDoom.Unity.EntitySystem.Reflection
{
	public static class EntityReflectionConsts
	{
		public class Graphical
		{
			public static string GraphicalInterfaceName = "IGraphicalEntity`1";
			public static string GraphicalMethodName = "SetGraphics";
			public static int GraphicalDataGenericArgIndex = 0;
			public static int ProcessedGraphicalDataGenericArgIndex = 1;
		}

		public class Functional
		{
			public static string FunctionalInterfaceName = "IFunctionalEntity`1";
			public static string FunctionalMethodName = "SetFromFunctionalData";
		}
	}
}