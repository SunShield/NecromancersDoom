using NDoom.Unity.Battle.Environment.Players.Cards.Deck;
using NDoom.Unity.Battle.Environment.Players.Cards.Library;
using NDoom.Unity.Battle.Environment.Players.Cards.Hand;
using NDoom.Unity.Battle.Environment.Players.Cards.Graveyard;
using NDoom.Unity.Environment.Main;
using UnityEngine;
using System.Collections.Generic;
using Zenject;
using NDoom.Core.Environment.EventSystem;
using NDoom.Core.EventSystem.Concrete.Events.Cards;
using NDoom.Core.EventSystem.Concrete.Args;

namespace NDoom.Unity.Battle.Environment.Players.Cards
{
    public class PlayerCardsController : ExtendedMonoBehaviour
    {
        [SerializeField] private PlayerDeck _deck;
        [SerializeField] private PlayerLibrary _library;
        [SerializeField] private PlayerHand _hand;
        [SerializeField] private PlayerGraveyard _graveyard;

        [Inject] private EventBus _eventBus;

        private BattlePlayer _player;
        private bool _isInitialized;

        public IReadOnlyList<PlayerCard> Cards => _deck.Cards;

        public void Initialize(BattlePlayer player)
        {
            _player = player;
            InitializePlayerSystems();
            SubscribeForPlayerCardEvents();
            _isInitialized = true;
        }

        private void InitializePlayerSystems()
        {
            _deck.AddCards(_player.GetDeck(), _player);
            _library.FillLibrary(_deck.Cards);
            _hand.Initialize(_player);
        }

        private void SubscribeForPlayerCardEvents()
        {
            _eventBus.GetEvent<OnFinishPlayerCardPlaying>().SubscribeForGlobal(OnPlayerCardPlayed);
        }

        // TODO: investigate a bug with wrong cards behaviour if a lot of cards player simultaneously
        private void OnPlayerCardPlayed(PlayerCardArgs args)
        {
            if (_player.Side != args.Card.Owner.Side) return;

            // if there are no cards in library, add cards from graveyard to it
            RefillLibraryIfNeeded();

            var playedCard = args.Card;
            MovePlayerCardOnGraveyard(playedCard);
        }

        private void RefillLibraryIfNeeded() { if (_library.Count == 0) _library.FillLibrary(_graveyard.PickAllCards()); }

        private void MovePlayerCardOnGraveyard(PlayerCard card)
        {
            _hand.RemoveCard(card);
            _graveyard.AddCard(card);
        }

        public override void UpdateManually()
        {
            if (!_isInitialized) return;

            if (_hand.HasCardInFirstSpot) return;
            var topLibraryCard = _library.GrabTopCard();

            _hand.AddCard(topLibraryCard);
        }
    }
}
