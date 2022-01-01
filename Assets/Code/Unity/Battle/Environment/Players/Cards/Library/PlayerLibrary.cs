using NDoom.Unity.Environment.Main;
using NDoom.Unity.Service;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Library
{
    // TODO: refactor Library and Graveyard later
    // (those can have a lot of identical logic, probably need common abstraction)
    public class PlayerLibrary : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardsOrigin;

        private readonly List<PlayerCard> _cards = new List<PlayerCard>();
        public int Count => _cards.Count;

        public void FillLibrary(IReadOnlyCollection<PlayerCard> cards)
        {
            foreach(var card in cards)
                _cards.Add(card);

            Shuffle();
        }

        public void AddCard(PlayerCard card, CardAddArgs args)
        {
            _cards.Insert(args.PositionFromTop, card);
            card.transform.parent = _cardsOrigin;
            card.transform.localPosition = Vector3.zero;
            Shuffle();
        }

        public void Shuffle() => _cards.Shuffle();

        public PlayerCard PickCard(int index)
        {
            var card = _cards[index];
            return card;
        }

        public PlayerCard PickTopCard() => PickCard(0);

        public PlayerCard GrabCard(int index)
        {
            if (_cards.Count == 0) return null;

            var card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }

        public PlayerCard GrabTopCard() => GrabCard(0);
    }
}
