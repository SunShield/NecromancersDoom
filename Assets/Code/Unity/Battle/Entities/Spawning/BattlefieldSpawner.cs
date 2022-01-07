using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using NDoom.Unity.EntitySystem.Spawning;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattlefieldSpawner 
		: PositionableEntitySpawner<Battlefield, BattlefieldSpawnArgs, BattleU, BattlefieldPositioningData>
	{
		protected override string GetEntityName(BattlefieldSpawnArgs args) => $"Battlefield [{args.Position.Side}]";

		protected override void ProcessEntityPostPositionSet(Battlefield entity, BattlefieldSpawnArgs args)
		{
			SetBattlefieldPlayer(entity, args);
			SetBattlefieldSize(entity, args);
			SetBattlefieldPos(entity, args.Position.Side, args.Offset);
		}

		private void SetBattlefieldPlayer(Battlefield entity, BattlefieldSpawnArgs args) => entity.SetPlayer(args.Player);
		private void SetBattlefieldSize(Battlefield entity, BattlefieldSpawnArgs args)=> entity.SetSize(args.Rows, args.Cols);

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