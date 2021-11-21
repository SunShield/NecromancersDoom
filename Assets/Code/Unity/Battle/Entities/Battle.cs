using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Graphical;
using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Battle : Entity, IAncestorEntity<Battlefield, Battle>, IGraphicalEntity<BattleGraphicalData>
	{
		private readonly Dictionary<BattlefieldSide, Battlefield> _battlefields =
			new Dictionary<BattlefieldSide, Battlefield>()
			{
				{ BattlefieldSide.Left, null },
				{ BattlefieldSide.Right, null },
			};
		public IReadOnlyDictionary<BattlefieldSide, Battlefield> Battlefields => _battlefields;

		private Transform GraphicsOrigin { get; set; }

		protected override void InitializeEntity()
		{
		}

		public void AddChild(Battlefield entity) => _battlefields[entity.Side] = entity;
		public void RemoveChild(Battlefield entity) => _battlefields[entity.Side] = null;

		public void SetGraphics(BattleGraphicalData graphicalData)
		{
			
		}
	}
}