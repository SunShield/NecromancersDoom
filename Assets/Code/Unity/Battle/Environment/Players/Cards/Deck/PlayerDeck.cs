using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Cards.Deck
{
    public class PlayerDeck : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _cardsOrigin;
        [SerializeField] private PlayerCard _cardPrefab;

        [Inject] private ExtendedMonoBehaviourSpawner _spawner;

        private readonly List<PlayerCard> _cards = new List<PlayerCard>();
        public IReadOnlyList<PlayerCard> Cards => _cards;
        public PlayerCard Prefab => _cardPrefab;

        public void AddCards(IReadOnlyList<(string unitName, UnitFunctionalData overridenData)> playerUnits)
        {
            foreach(var cardData in playerUnits)
                AddCard(cardData.unitName, cardData.overridenData);
        }

        public void AddCard(string unitName, UnitFunctionalData overridenData = null)
        {
            var card = _spawner.SpawnMonoBehaviour(_cardPrefab);
            card.Initialize(unitName, overridenData);
            card.transform.parent = _cardsOrigin;
            card.transform.localPosition = Vector3.zero;
            _cards.Add(card);
        }
    }
}
