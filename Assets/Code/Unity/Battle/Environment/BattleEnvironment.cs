using NDoom.Unity.Battle.Environment.Players;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment
{
    public class BattleEnvironment : ExtendedMonoBehaviour
    {
        [SerializeField] private BattlePlayer _humanPlayer;
        [SerializeField] private BattlePlayer _aiPlayer;

        public void Initialize()
        {
            _humanPlayer.Initialize(BattlefieldSide.Left);
            _aiPlayer.Initialize(BattlefieldSide.Right);
        }
    }
}
