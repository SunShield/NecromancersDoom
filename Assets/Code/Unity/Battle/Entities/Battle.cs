using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Graphical;
using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.Battles.Entities.Data.Structural;
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

		private Transform BattlefieldsOrigin { get; set; }
		private Transform GraphicsOrigin { get; set; }

		protected override void InitializeEntityInternal() {}

		public void AddChild(Battlefield entity)
		{
			_battlefields[entity.Side] = entity;
			entity.transform.parent = BattlefieldsOrigin;
		}

		public void RemoveChild(Battlefield entity) => _battlefields[entity.Side] = null;
		public void SetGraphics(BattleProcessedGraphicalData graphicalData)
			=> graphicalData.BattleBg.transform.parent = GraphicsOrigin;
	}
}