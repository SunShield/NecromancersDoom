using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Deck
{
    public class PlayerDeck : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardsOrigin;
        [SerializeField] private UnitCard _cardPrefab;

        private readonly List<UnitCard> _cards = new List<UnitCard>();
        public IReadOnlyList<UnitCard> Cards => _cards;

        public void AddCard(string unitName, UnitFunctionalData overridenData = null)
        {
            var card = Instantiate(_cardPrefab, _cardsOrigin.position, Quaternion.identity, _cardsOrigin);
            card.Initialize(unitName, overridenData);
        }
    }
}
