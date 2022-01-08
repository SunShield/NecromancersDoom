using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Components.Units;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Graphical;
using NDoom.Unity.Battles.Entities.Data.Concrete.Mechanical.Unit;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.UI.Unit;
using NDoom.Unity.EntitySystem;
using NDoom.Unity.EntitySystem.Interfaces;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities
{
	public class Unit
		: Entity, 
		  IChildEntity<Tile, Unit>,
		  IAncestorEntity<Skill, Unit>,
		  IGraphicalEntity<UnitGraphicalData, UnitProcessedGraphicalData>,
		  IFunctionalEntity<UnitFunctionalData>
	{
		[SerializeField] private Transform _graphicsOrigin;
		[SerializeField] private Transform _skillsOrigin;
		[SerializeField] private UnitHealthUi _healthUi;
		[SerializeField] private UnitResourceUi _resourceUi;
		[SerializeField] private UnitResourceRegenerationController _resourceRegenerationController;

		public Tile Tile { get; private set; }
		public List<Skill> Skills { get; private set; } = new List<Skill>();
		public UnitMechanicalData Data { get; private set; }
		public BattlefieldSide Side => Tile.Side;

		public override void InitializeEntityPostSpawn()
		{
			_healthUi.Initialize(this);
			_resourceUi.Initialize(this);
			_resourceRegenerationController.Initialize(this);
			_resourceRegenerationController.SetPlayer(Tile.Battlefield.OwningPlayer);
		}

		public void BindToAncestor(Tile ancestor) => Tile = ancestor;
		public void SetFromFunctionalData(UnitFunctionalData functionalData) => Data = functionalData.ToMechanicalData();

		public void SetGraphics(UnitProcessedGraphicalData graphicalData)
		{
			var graphicsInstanceTran = graphicalData.GraphicsInstance.transform;
			graphicsInstanceTran.parent = _graphicsOrigin;
			graphicsInstanceTran.position = Vector3.zero;
		}

		public void AddChild(Skill entity)
		{
			Skills.Add(entity);
			entity.transform.parent = _skillsOrigin;
		}

		public void RemoveChild(Skill entity)
		{
			Skills.Remove(entity);
		}

		public void PaySkill(Skill skill)
		{
			Data.Resource.Current -= skill.Data.Cost;
		}
	}
}