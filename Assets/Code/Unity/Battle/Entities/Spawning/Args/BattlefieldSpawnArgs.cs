using NDoom.Unity.Battle.Environment.Players;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.EntitySystem.Spawning.Args;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattlefieldSpawnArgs
		: PositionableEntitySpawnArgs<BattleU, Battlefield, BattlefieldPositioningData>
	{
		public int Rows { get; set; }
		public int Cols { get; set; }
		public Vector2 Offset { get; set; }
		public BattlePlayer Player { get; set; }
	}
}