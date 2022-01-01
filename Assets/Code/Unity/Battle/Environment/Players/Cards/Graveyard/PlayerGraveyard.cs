using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Graveyard
{
    public class PlayerGraveyard : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardsOrigin;

        private readonly List<PlayerCard> _cards = new List<PlayerCard>();
        public int Count => _cards.Count;

        public void AddCard(PlayerCard card)
        {
            _cards.Add(card);
            card.transform.parent = _cardsOrigin;
            card.transform.localPosition = Vector3.zero;
        }

        public PlayerCard PickCard(int index)
        {
            var card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }
    }
}
