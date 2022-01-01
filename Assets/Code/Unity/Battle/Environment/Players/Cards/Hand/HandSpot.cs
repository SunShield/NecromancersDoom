using NDoom.Unity.Environment.Main;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class HandSpot : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardOrigin;
        [SerializeField] private float _cardMoveSpeed = 20f;

        [ShowInInspector] public PlayerCard Card { get; private set; }
        public int Index { get; private set; }
        public bool IsEmpty => Card == null;

        public void Initialize(int index) => Index = index;

        public void SetCard(PlayerCard card)
        {
            Card = card;
            card.transform.parent = _cardOrigin;
        }

        public override void UpdateManually()
        {
            if (Card == null) return;

            var cardTransform = Card.transform;
            var cardY = Mathf.Clamp(cardTransform.position.y - _cardMoveSpeed * Time.deltaTime, _cardOrigin.position.y, 100f);
            cardTransform.position = new Vector3(cardTransform.position.x, cardY, cardTransform.position.z);
        }

        private void OnMouseDown() => OnCardClicked();

        private void OnCardClicked() => onCardSpotClicked?.Invoke(Index);

        public event Action<int> onCardSpotClicked;
    }
}
