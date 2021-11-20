using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Concrete;
using NDoom.Unity.Battles.Entities.Concrete.Data;
using NDoom.Unity.Battles.Entities.Initialization;
using NDoom.Unity.Battles.Entities.Spawning.Args;
using UnityEngine;

namespace NDoom.Unity.Battles.Entities.Spawning
{
	public class BattlefieldSpawner
	{
		[SerializeField] private Battlefield _prefab;

		private readonly Dictionary<BattlefieldSide, Vector2> _positions = new Dictionary<BattlefieldSide, Vector2>()
		{
			{ BattlefieldSide.Left, BattleEntitySpawnConsts.LeftBattlefieldPosition },
			{ BattlefieldSide.Right, BattleEntitySpawnConsts.RightBattlefieldPosition },
		};

		//protected override Battlefield GetPrefab(BattlefieldSpawnArgs args) => _prefab;
		//protected override void RenameEntity(Battlefield entity, BattlefieldInitArgs args) => entity.name = $"Battlefield [{args.Side}]";

		//protected override void PostEntitySpawn(Battlefield entity, BattlefieldInitArgs args)
		//{
		//	entity.transform.position = _positions[entity.Side];
		//}
	}
}