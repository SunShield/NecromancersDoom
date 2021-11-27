using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Positioning;
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
					{ BattlefieldSide.Left, new Vector2(-8f, 0f) },
					{ BattlefieldSide.Left, new Vector2(8f, 0f) }
				};
		}
	}
}