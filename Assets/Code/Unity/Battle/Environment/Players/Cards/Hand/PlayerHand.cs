using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class PlayerHand : ExtendedMonoBehaviour
    {
        private const int NoEmptySpot = -1;

        [SerializeField] private Transform _rightSpotPositionMarker;
        [SerializeField] private Transform _leftSpotPositionMarker;
        [SerializeField] private Transform _spotsOrigin;
        [SerializeField] private HandSpot _handSpotPrefab;

        [Inject] private ExtendedMonoBehaviourSpawner _spawner;

        private readonly List<HandSpot> _cardSpots = new List<HandSpot>();

        public BattlefieldSide Side { get; private set; }
        public int HandSize { get; private set; }
        public bool IsFull => CheckHandFull();
        public bool HasCardInFirstSpot => !_cardSpots[0].IsEmpty;

        public void Initialize(BattlefieldSide side)
        {
            HandSize = 4;
            Side = side;
            PopulateSpots();
        }

        // TODO: add support for dynamic change of and size
        // Static size for now
        private void PopulateSpots()
        {
            var distance = (_rightSpotPositionMarker.position - _leftSpotPositionMarker.position) / (HandSize - 1);

            for (int i = 0; i < HandSize; i++)
                PopulateSpot(distance, i);
        }

        private void PopulateSpot(Vector3 distance, int spotIndex)
        {
            var spot = _spawner.SpawnMonoBehaviour(_handSpotPrefab);
            RenameSpot(spot, spotIndex);
            ConfigureSpotTransform(spot, distance, spotIndex);
            InitSpot(spot, spotIndex);
            _cardSpots.Add(spot);
        }

        private void RenameSpot(HandSpot spot, int spotIndex) => spot.name = $"Spot [{spotIndex}]";

        private void ConfigureSpotTransform(HandSpot spot, Vector3 distance, int spotIndex)
        {
            var tran = spot.transform;
            tran.position = _leftSpotPositionMarker.position + distance * spotIndex;
            tran.parent = _spotsOrigin;
        }

        private void InitSpot(HandSpot spot, int spotIndex) => spot.Initialize(Side, spotIndex);

        public bool CheckHandFull()
        {
            foreach (var spot in _cardSpots)
                if (spot.IsEmpty) return false;

            return true;
        }

        public void AddCard(PlayerCard card)
        {
            var fistSpot = _cardSpots[0];
            fistSpot.SetCard(card);
            card.SetLocation(PlayerCardLocation.Hand);
        }

        public override void UpdateManually()
        {
            for(int i = HandSize - 1; i >= 1; i--)
            {
                var currentSpot = _cardSpots[i];
                var previousSpot = _cardSpots[i - 1];

                if (!currentSpot.IsEmpty) continue;
                if (previousSpot.IsEmpty) continue;
                if (!previousSpot.CardArrived) continue;

                MoveCardBetweenSpots(previousSpot, currentSpot);
            }
        }

        private void MoveCardBetweenSpots(HandSpot currentSpot, HandSpot nextSpot)
        {
            var card = currentSpot.Card;
            currentSpot.SetCard(null);
            nextSpot.SetCard(card);
        }

        public void RemoveCard(PlayerCard card)
        {
            for(int i = 0; i < HandSize; i++)
            {
                var currentSpot = _cardSpots[i];
                if (currentSpot.Card != card) continue;

                currentSpot.SetCard(null);
                break;
            }
        }
    }
}
