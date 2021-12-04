using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Unit
		: Entity, 
		  IChildEntity<Tile, Unit>,
		  IGraphicalEntity<UnitGraphicalData, UnitProcessedGraphicalData>,
		  IFunctionalEntity<UnitFunctionalData>
	{
		[SerializeField] private Transform _graphicsOrigin;

		public Tile Tile { get; private set; }
		public UnitFunctionalData UnitData { get; private set; }

		public void BindToAncestor(Tile ancestor) => Tile = ancestor;
		public void SetFromFunctionalData(UnitFunctionalData functionalData) => UnitData = functionalData;

		public void SetGraphics(UnitProcessedGraphicalData graphicalData)
		{
			var graphicsInstanceTran = graphicalData.GraphicsInstance.transform;
			graphicsInstanceTran.parent = _graphicsOrigin;
			graphicsInstanceTran.position = Vector3.zero;
		}
	}
}