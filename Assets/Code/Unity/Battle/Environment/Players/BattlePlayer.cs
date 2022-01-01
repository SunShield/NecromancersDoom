using NDoom.Unity.Battle.Environment.Players.Cards;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Battle.Environment.Players
{
    /// <summary>
    /// Class presenting player in battle. Contains player's actual deck, skill data,
    /// active skills state, etc
    /// </summary>
    public class BattlePlayer : ExtendedMonoBehaviour
    {
        [SerializeField] private PlayerCardsController _cardsController;

        public BattlefieldSide Side { get; private set; }

        private List<(string untiName, UnitFunctionalData overridenData)> _deck = new List<(string untiName, UnitFunctionalData overridenData)>();
        public IReadOnlyList<(string untiName, UnitFunctionalData overridenData)> Deck => _deck;

        public void Initialize(BattlefieldSide side)
        {
            Side = side;
            SetDeck();
            InitializeCardsController();
        }

        public void SetDeck()
        {
            // TODO: some logic here later, test logic now
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
            _deck.Add(("Skeleton", null));
        }

        private void InitializeCardsController() => _cardsController.Initialize(this);
    }
}
