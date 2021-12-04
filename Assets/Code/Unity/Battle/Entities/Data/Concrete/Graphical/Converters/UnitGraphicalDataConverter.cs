using NDoom.Unity.EntitySystem.DataStructure.Data.Converters;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters
{
	public class UnitGraphicalDataConverter : GraphicalDataConverter<UnitGraphicalData, UnitProcessedGraphicalData>
	{
		[Inject] private DiContainer _container;

		public override UnitProcessedGraphicalData Process(UnitGraphicalData data)
		{
			return new UnitProcessedGraphicalData()
			{
				GraphicsInstance = _container.InstantiatePrefab(data.Prefab)
			};
		}
	}
}