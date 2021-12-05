using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Skill
		: Entity, 
			IChildEntity<Unit, Skill>,
			IGraphicalEntity<SkillGraphicalData, SkillProcessedGraphicalData>,
			IFunctionalEntity<SkillFunctionalData>
	{
		[SerializeField] private Transform _graphicsOrigin;

		public Unit Holder { get; private set; }
		public SkillFunctionalData Data { get; private set; }

		public void BindToAncestor(Unit ancestor) => Holder = ancestor;
		public void SetFromFunctionalData(SkillFunctionalData functionalData) => Data = functionalData;

		public void SetGraphics(SkillProcessedGraphicalData graphicalData)
		{
			var graphicsInstanceTran = graphicalData.GraphicsInstance.transform;
			graphicsInstanceTran.parent = _graphicsOrigin;
			graphicsInstanceTran.position = Vector3.zero;
		}
	}
}