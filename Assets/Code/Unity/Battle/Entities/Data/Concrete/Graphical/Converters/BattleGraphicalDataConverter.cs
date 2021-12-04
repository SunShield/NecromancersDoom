using NDoom.Unity.EntitySystem.DataStructure.Data.Converters;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters
{
	public class BattleGraphicalDataConverter : GraphicalDataConverter<BattleGraphicalData, BattleProcessedGraphicalData>
	{
		[Inject] private DiContainer _container;

		public override BattleProcessedGraphicalData Process(BattleGraphicalData data)
		{
			return new BattleProcessedGraphicalData()
			{
				BattleBg = _container.InstantiatePrefab(data.Prefab)
			};
		}
	}
}