using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.Entities;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Concrete
{
	public class Tile
	{
		[SerializeField] private Transform _effectsOrigin;
		[SerializeField] private Transform _unitOrigin;

		public int Row { get; private set; }
		public int Col { get; private set; }
		public Battlefield Battlefield { get; private set; }
		public Unit Unit { get; private set; }
	}
}