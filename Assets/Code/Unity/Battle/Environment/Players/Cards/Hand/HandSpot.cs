using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class HandSpot : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardOrigin;
        [SerializeField] private float _cardMoveSpeed = 20f;

        public PlayerCard Card { get; private set; }

        public void SetCard(PlayerCard card)
        {
            Card = card;
            card.transform.parent = _cardOrigin;
        }

        private void Update()
        {
            if (Card == null) return;

            var tran = Card.transform;
            tran.position = new Vector3(tran.position.x, Mathf.Max(tran.position.y - _cardMoveSpeed * Time.deltaTime, _cardOrigin.position.y, tran.position.z));
        }
    }
}
