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

        public string UnitName { get; private set; }

        // Used to override default data is unit has equipment, upgrades, etc
        public UnitFunctionalData OverridenData { get; private set; }
        public BattlePlayer Owner { get; private set; }

        public void Initialize(string unitName, UnitFunctionalData overridenData, BattlePlayer owner)
        {
            UnitName = unitName;
            OverridenData = overridenData;
            Owner = owner;
        }

        private void OnMouseDown() => OnCardClicked();

        private void OnCardClicked() => _eventBus.GetEvent<OnStartPlayerCardPlaying>().InvokeForGlobal(new PlayerCardArgs(this));
    }
}
