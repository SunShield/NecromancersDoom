using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
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

        private List<HandSpot> _cardSpots = new List<HandSpot>();

        public int HandSize { get; private set; }
        public bool IsFull => CheckHandFull();

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

        private void InitSpot(HandSpot spot, int spotIndex) 
        { 
            spot.Initialize(spotIndex);
            spot.onCardSpotClicked += OnSpotClicked;
        }

        private void OnSpotClicked(int spotIndex)
        {
        }

        public bool CheckHandFull()
        {
            foreach (var spot in _cardSpots)
                if (spot.IsEmpty) return false;

            return true;
        }

        public void AddCard(PlayerCard card)
        {
            var freeIndex = GetHighestFreeIndex();
            if (freeIndex == NoEmptySpot) return;

            var freeSpot = _cardSpots[freeIndex];
            Debug.Log($"Spot: {freeSpot.Index} | Free: {freeIndex}");
            freeSpot.SetCard(card);
        }

        private int GetHighestFreeIndex()
        {
            for(int i = HandSize - 1; i >= 0; i--)
                if (_cardSpots[i].IsEmpty) return i;

            return NoEmptySpot;
        }
    }
}
