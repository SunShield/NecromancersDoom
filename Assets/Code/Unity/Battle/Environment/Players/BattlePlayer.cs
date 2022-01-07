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
        public PlayerMechanicalData Data { get; private set; } = new PlayerMechanicalData();
        public PlayerTickState TickState { get; private set; } = new PlayerTickState();

        public void Initialize(BattlefieldSide side)
        {
            Side = side;
            InitializeCardsController();
        }

        public List<(string untiName, UnitFunctionalData overridenData)> GetDeck()
        {
	        // TODO: later fetch this info from elsewhere?
			var result = new List<(string untiName, UnitFunctionalData overridenData)>
			{
				("Skeleton", null),
				("Skeleton", null),
				("Skeleton", null),
				("Skeleton", null),
				("Skeleton", null),
				("Skeleton", null)
			};
			return result;
        }

        private void InitializeCardsController() => _cardsController.Initialize(this);
    }
}
