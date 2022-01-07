using NDoom.Unity.Battle.Environment.Systems;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class HandSpot : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardOrigin;
        [SerializeField] private float _cardMoveSpeed = 20f;

        private BattlePlayer _owner;

        [ShowInInspector] public PlayerCard Card { get; private set; }
        public int Index { get; private set; }
        public bool CardArrived { get; private set; }
        public BattlefieldSide Side => _owner.Side;
        public bool IsEmpty => Card == null;

        public void Initialize(BattlePlayer owner, int index)
        {
	        _owner = owner;
	        Index = index;
        }

        public void SetCard(PlayerCard card)
        {
            Card = card;
            CardArrived = false;

            if (card != null) card.Transform.parent = _cardOrigin;
        }

        public override void UpdateManually()
        {
            if (Card == null) return;

            var cardTransform = Card.Transform;
            var cardY = CalculateCardY(cardTransform);
            MoveCardToSpot(cardTransform, cardY);
            if (cardY == _cardOrigin.position.y) OnCardArrive();
        }

        private float CalculateCardY(Transform cardTransform) 
            => Mathf.Clamp(cardTransform.position.y - _cardMoveSpeed * Time.deltaTime * GetRelativeTick(), _cardOrigin.position.y, 100f);

        private float GetRelativeTick() => _owner.TickState.ReversedRelativeTick;

        private void MoveCardToSpot(Transform cardTransform, float cardY) 
            => cardTransform.position = new Vector3(cardTransform.position.x, cardY, cardTransform.position.z);

        private void OnCardArrive() => CardArrived = true;
    }
}
