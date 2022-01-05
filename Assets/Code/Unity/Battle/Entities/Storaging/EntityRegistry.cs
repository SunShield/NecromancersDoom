using NDoom.Unity.Battles.Entities;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using System.Collections.Generic;

namespace NDoom.Unity.Battle.Entities.Storaging
{
    public class EntityRegistry
    {
        public readonly IReadOnlyDictionary<BattlefieldSide, List<Unit>> Units = new Dictionary<BattlefieldSide, List<Unit>>()
        {
            { BattlefieldSide.Left,  new List<Unit>() },
            { BattlefieldSide.Right, new List<Unit>() },
        };

        public BattleU Battle { get; private set; }

        public void RegisterBattle(BattleU battle) => Battle = battle;

        public void RegisterUnit(Unit unit)
        {
            var side = unit.Tile.Battlefield.Side;
            Units[side].Add(unit);
        }
    }
}
