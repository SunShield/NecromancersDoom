using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Graveyard
{
    public class PlayerGraveyard : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardsOrigin;
        [SerializeField] private float _cardMoveSpeed = 100f;

        private readonly List<PlayerCard> _cards = new List<PlayerCard>();
        public int Count => _cards.Count;

        public void AddCard(PlayerCard card)
        {
            _cards.Add(card);
            card.SetLocation(PlayerCardLocation.Graveyard);
            card.transform.parent = _cardsOrigin;
        }

        public PlayerCard PickCard(int index)
        {
            var card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }

        public List<PlayerCard> PickAllCards()
        {
            var cards = new List<PlayerCard>(_cards);
            _cards.Clear();
            return cards;
        }

        public override void UpdateManually()
        {
            foreach(var card in _cards)
                MoveCardToOrigin(card);
        }

        private void MoveCardToOrigin(PlayerCard card)
        {
            if (card.Transform.position == _cardsOrigin.position) return;

            var cardY = CalculateCardY(card.Transform);
            MoveCardToSpot(card.Transform, cardY);
        }

        private float CalculateCardY(Transform cardTransform)
           => Mathf.Clamp(cardTransform.position.y - _cardMoveSpeed * Time.deltaTime, _cardsOrigin.position.y, 100f);

        private void MoveCardToSpot(Transform cardTransform, float cardY)
           => cardTransform.position = new Vector3(cardTransform.position.x, cardY, cardTransform.position.z);
    }
}
