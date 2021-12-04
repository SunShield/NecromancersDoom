using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public static class BattleEntitiesSpawningConsts
	{
		public class Battle
		{
			public static readonly IReadOnlyDictionary<BattlefieldSide, Vector2> DefaultBattlefieldPositions =
				new Dictionary<BattlefieldSide, Vector2>()
				{
					{ BattlefieldSide.Left,  new Vector2(-3f, 0f) },
					{ BattlefieldSide.Right, new Vector2(3f, 0f) }
				};

			public const float TileUnitsSize = 1.28f;
		}
	}
}