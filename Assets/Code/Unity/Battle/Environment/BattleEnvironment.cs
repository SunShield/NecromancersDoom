using NDoom.Unity.Battle.Environment.Players;
using NDoom.Unity.Battle.Environment.Players.Cards;
using NDoom.Unity.Battle.Environment.Systems;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment
{
    public class BattleEnvironment : ExtendedMonoBehaviour
    {
        [SerializeField] private BattlePlayer _humanPlayer;
        [SerializeField] private BattlePlayer _aiPlayer;

        [Inject] private PlayerCardPlayer _cardsPlayer;
        [Inject] private PlayersTickController _tickController;

        public void Initialize()
        {
            _humanPlayer.Initialize(BattlefieldSide.Left);
            _aiPlayer.Initialize(BattlefieldSide.Right);
            _humanPlayer.Data.TickTime.BaseValue = 200f;
            _tickController.Initialize(_humanPlayer, _aiPlayer);
            _cardsPlayer.Initialize();
        }
    }
}
