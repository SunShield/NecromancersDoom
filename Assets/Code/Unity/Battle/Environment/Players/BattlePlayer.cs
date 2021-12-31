using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players
{
    /// <summary>
    /// Class presenting player in battle. Contains player's actual deck, skill data,
    /// active skills state, etc
    /// </summary>
    public class BattlePlayer : ExtendedMonoBehaviour
    {
        public BattlefieldSide Side { get; private set; }

        public void Initialize(BattlefieldSide side) => Side = side;
    }
}
