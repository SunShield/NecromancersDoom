﻿using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Battles.Entities.Data.Concrete.Structural;
using NDoom.Unity.EntitySystem.Spawning.Args;

namespace NDoom.Unity.Battles.Entities.Spawning.Args
{
	public class BattlefieldSpawnArgs
		: PositionableEntitySpawnArgs<Battle, Battlefield, BattlefieldPositioningData>,
		  IStructurableEntitySpawnArgs<BattlefieldStructuralData>
	{
		public BattlefieldStructuralData StructuralData { get; set; }
	}
}