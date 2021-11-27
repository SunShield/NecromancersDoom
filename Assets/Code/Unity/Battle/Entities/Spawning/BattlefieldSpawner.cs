using NDoom.Unity.Battles.Entities.Data.Positioning;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattlefieldSpawner 
		: PositionableEntitySpawner<Battlefield, BattlefieldSpawnArgs, Battle, BattlefieldPositioningData>
	{
		protected override string GetEntityName(BattlefieldSpawnArgs args) => $"Battlefield [{args.Position.Side}]";

		protected override void ProcessEntityPostPositionSet(Battlefield entity, BattlefieldSpawnArgs args)
		{
			SetBattlefieldSize(entity, args);
			SetBattlefieldPos(entity, args.Position.Side, args.StructuralData.Offset);
		}

		private static void SetBattlefieldSize(Battlefield entity, BattlefieldSpawnArgs args)
			=> entity.SetSize(args.StructuralData.Rows, args.StructuralData.Cols);

		private void SetBattlefieldPos(Battlefield entity, BattlefieldSide side, Vector2 offset)
		{
			var defaultPos = BattleEntitiesSpawningConsts.Battle.DefaultBattlefieldPositions[side];
			var finalOffset = side == BattlefieldSide.Left
				? offset
				: new Vector2(-1 * offset.x, offset.y);
			var finalPos = defaultPos + finalOffset;
			entity.transform.position = finalPos;
		}
	}
}