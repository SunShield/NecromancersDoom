using NDoom.Unity.Battle.Environment.Players;
using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment
{
    public class BattleEnvironment : ExtendedMonoBehaviour
    {
        [SerializeField] private BattlePlayer _humanPlayer;
        [SerializeField] private BattlePlayer _aiPlayer;
    }
}
