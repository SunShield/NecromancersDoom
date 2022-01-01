using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class PlayerHand : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _rightSpotPositionMarker;
        [SerializeField] private Transform _leftSpotPositionMarker;
        [SerializeField] private Transform _spotsOrigin;
        [SerializeField] private HandSpot _handSpotPrefab;

        private List<HandSpot> _cardSpots = new List<HandSpot>();

        public int HandSize { get; private set; }

        public void Initialize()
        {
            HandSize = 4;
            PopulateSpots();
        }

        // TODO: add support for dynamic change of ahnd size
        // Static size for now
        private void PopulateSpots()
        {
            var distance = (_rightSpotPositionMarker.position - _leftSpotPositionMarker.position) / (HandSize - 1);

            for (int i = 0; i < HandSize; i++)
            {
                var spot = Instantiate(_handSpotPrefab, _leftSpotPositionMarker.position + distance * i, Quaternion.identity, _spotsOrigin);
                spot.transform.localScale = Vector3.one;
                _cardSpots.Add(spot);
            }
        }

        public void AddCard(PlayerCard card)
        {

        }
    }
}
