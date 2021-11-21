using NDoom.Unity.EntitySystem.Reflection;
using Zenject;

namespace NDoom.Unity.EntitySystem
{
	public class EntitySystemMain
	{
		[Inject] private EntityReflectionDataBuilder _entityReflectionDataBuilder;
		[Inject] private EntityReflectionDataStorage _entityReflectionDataStorage;

		public void InitializeSystem()
		{
			_entityReflectionDataStorage.Fill(_entityReflectionDataBuilder.BuildForAllEntities());
		}
	}
}