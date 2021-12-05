using NDoom.Unity.EntitySystem.DataStructure.Data.Converters;
using Zenject;

namespace NDoom.Unity.Battles.Entities.Data.Concrete.Graphical.Converters
{
	public class SkillGraphicalDataConverter : GraphicalDataConverter<SkillGraphicalData, SkillProcessedGraphicalData>
	{
		[Inject] private DiContainer _container;

		public override SkillProcessedGraphicalData Process(SkillGraphicalData data)
			=> new SkillProcessedGraphicalData() { GraphicsInstance =  _container.InstantiatePrefab(data.Prefab) };
	}
}