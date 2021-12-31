using NDoom.Unity.Environment.Main;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Hand
{
    public class HandSpot : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardOrigin;
        public UnitCard Card { get; private set; }
    }
}
