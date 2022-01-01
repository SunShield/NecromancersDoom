using NDoom.Unity.Battle.Environment.Players.Cards.Deck;
using NDoom.Unity.Battle.Environment.Players.Cards.Library;
using NDoom.Unity.Battle.Environment.Players.Cards.Hand;
using NDoom.Unity.Battle.Environment.Players.Cards.Graveyard;
using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards
{
    public class PlayerCardsController : ExtendedMonoBehaviour
    {
        [SerializeField] private PlayerDeck _deck;
        [SerializeField] private PlayerLibrary _library;
        [SerializeField] private PlayerHand _hand;
        [SerializeField] private PlayerGraveyard _graveyard;

        private BattlePlayer _player;
        private bool _isInitialized;

        private float _cardHeight;

        public void Initialize(BattlePlayer player)
        {
            _player = player;
            _deck.AddCards(player.Deck);
            _library.FillLibrary(_deck.Cards);
            _hand.Initialize();
            CalculateParameters();
            _isInitialized = true;
        }

        private void CalculateParameters()
        {
            _cardHeight = _deck.Prefab.GetComponentInChildren<Renderer>().bounds.size.y;
        }

        public override void UpdateManually()
        {
            if (!_isInitialized) return;

            if (_hand.IsFull) return;
            var libraryCard = _library.GrabTopCard();
            _hand.AddCard(libraryCard);
        }
    }
}
