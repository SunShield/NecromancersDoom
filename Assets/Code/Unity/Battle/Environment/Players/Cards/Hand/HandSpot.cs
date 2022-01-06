using NDoom.Unity.Battle.Environment.Systems;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class HandSpot : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardOrigin;
        [SerializeField] private float _cardMoveSpeed = 20f;

        [Inject] private PlayersTickController _tickController;

        [ShowInInspector] public PlayerCard Card { get; private set; }
        public BattlefieldSide Side { get; private set; }
        public int Index { get; private set; }
        public bool CardArrived { get; private set; }
        public bool IsEmpty => Card == null;

        public void Initialize(BattlefieldSide side, int index)
        {
	        Side = side;
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

        private float GetRelativeTick() => _tickController.PlayerTickStates[Side].ReversedRelativeTickSize;

        private void MoveCardToSpot(Transform cardTransform, float cardY) 
            => cardTransform.position = new Vector3(cardTransform.position.x, cardY, cardTransform.position.z);

        private void OnCardArrive() => CardArrived = true;
    }
}
