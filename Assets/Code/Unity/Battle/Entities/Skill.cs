using NDoom.Unity.Battles.Entities.Components.Skills;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Mechanics.Skills.Execution;
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
		[SerializeField] private SkillExecutionController _executionController;

		public Unit Holder { get; private set; }
		public SkillFunctionalData Data { get; private set; }
		public SkillExecutionActions Actions { get; private set; }

		public override void InitializeEntityPostSpawn()
		{
			_executionController.Initialize(this);
		}

		public void SetExecutionActions(SkillExecutionActions actions) => Actions = actions;

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