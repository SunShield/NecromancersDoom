using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.EntitySystem.Spawning.Args;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattlefieldSpawnArgs
		: PositionableEntitySpawnArgs<Battle, Battlefield, BattlefieldPositioningData>
	{
		public int Rows { get; set; }
		public int Cols { get; set; }
		public Vector2 Offset { get; set; }
	}
}