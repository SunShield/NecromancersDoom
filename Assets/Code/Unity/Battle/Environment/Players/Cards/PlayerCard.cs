using NDoom.Core.Environment.EventSystem;
using NDoom.Core.EventSystem.Concrete.Args;
using NDoom.Core.EventSystem.Concrete.Events.Cards;
using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Cards
{
    public class PlayerCard : ExtendedMonoBehaviour
    {
        [Inject] private EventBus _eventBus;

        public BattlePlayer Owner { get; private set; }
        public PlayerCardLocation Location { get; private set; }
        public string UnitName { get; private set; }

        // Used to override default data is unit has equipment, upgrades, etc
        public UnitFunctionalData OverridenData { get; private set; }

        public void Initialize(string unitName, UnitFunctionalData overridenData, BattlePlayer owner)
        {
            UnitName = unitName;
            OverridenData = overridenData;
            Owner = owner;
            Location = PlayerCardLocation.NoZone;
        }

        public void SetLocation(PlayerCardLocation location) => Location = location;

        private void OnMouseDown() => OnCardClicked();

        private void OnCardClicked() 
        {
            if (Location != PlayerCardLocation.Hand) return;

            _eventBus.GetEvent<OnStartPlayerCardPlaying>().InvokeForGlobal(new PlayerCardArgs(this)); 
        }
    }
}
