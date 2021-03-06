using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Tile 
		: Entity, 
		  IPositionableEntity<TilePositioningData, Battlefield, Tile>,
		  IAncestorEntity<Unit, Tile>
	{
		[SerializeField] private Transform _unitsOrigin;
		private Dictionary<int, Unit> _units = new Dictionary<int, Unit>();
		public IReadOnlyDictionary<int, Unit> Units => _units;

		public Battlefield Battlefield { get; private set; }
		public int Row { get; private set; }
		public int Col { get; private set; }
		public BattlefieldSide Side => Battlefield.Side;

		protected override void InitializeEntityPreSpawn() {}
		public void BindToAncestor(Battlefield ancestor) => Battlefield = ancestor;

		public void SetPosition(TilePositioningData data)
		{
			Row = data.Row;
			Col = data.Col;
		}

		public void AddChild(Unit entity)
		{
			_units.Add(entity.GlobalId, entity);
			entity.transform.parent = _unitsOrigin;
		}

		public void RemoveChild(Unit entity) => _units.Remove(entity.GlobalId);
	}
}