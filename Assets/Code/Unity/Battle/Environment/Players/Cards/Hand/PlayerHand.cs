using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class PlayerHand : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _rightSpotPosition;
        [SerializeField] private Transform _leftSpotPosition;

        private List<HandSpot> _cardSpots;

        public int HandSize { get; private set; }


    }
}
