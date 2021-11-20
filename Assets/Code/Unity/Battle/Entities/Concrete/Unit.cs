using NDoom.Core.DataManagement.DataStructure.Functional;
using NDoom.Core.DataManagement.DataStructure.Spawn;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities;
using NDoom.Unity.ScriptableObjects.Data.Unit;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Concrete
{
	public class Unit
	{
		[SerializeField] private Transform _skillsOrigin;
		[SerializeField] private Transform _effectOrigin;

		public Tile Tile { get; private set; }
		public UnitFunctionalData FunctionalData { get; private set; }

	}
}