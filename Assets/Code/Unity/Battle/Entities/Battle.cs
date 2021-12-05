using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Battle 
		: Entity, 
		  IAncestorEntity<Battlefield, Battle>, 
		  IGraphicalEntity<BattleGraphicalData, BattleProcessedGraphicalData>, 
		  IStructurableEntity<BattleStructuralData>
	{
		private readonly Dictionary<BattlefieldSide, Battlefield> _battlefields =
			new Dictionary<BattlefieldSide, Battlefield>()
			{
				{ BattlefieldSide.Left, null },
				{ BattlefieldSide.Right, null },
			};
		public IReadOnlyDictionary<BattlefieldSide, Battlefield> Battlefields => _battlefields;

		[SerializeField] private Transform _graphicsOrigin;
		[SerializeField] private Transform _battlefieldsOrigin;
		
		protected override void InitializeEntityPreSpawn() {}

		public void AddChild(Battlefield entity)
		{
			_battlefields[entity.Side] = entity;
			entity.transform.parent = _battlefieldsOrigin;
		}

		public void RemoveChild(Battlefield entity) => _battlefields[entity.Side] = null;

		public void SetGraphics(BattleProcessedGraphicalData graphicalData)
		{
			var graphicsInstanceTran = graphicalData.BattleBg.transform;
			graphicsInstanceTran.parent = _graphicsOrigin;
			graphicsInstanceTran.position = Vector3.zero;
		}
	}
}