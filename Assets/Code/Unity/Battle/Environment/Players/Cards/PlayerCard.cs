using NDoom.Unity.Battles.Entities.Data.Concrete.Functional;
using NDoom.Unity.Environment.Main;
using System;

namespace NDoom.Unity.Battle.Environment.Players.Cards
{
    public class PlayerCard : ExtendedMonoBehaviour
    {
        public string UnitName { get; private set; }

        // Used to override default data is unit has equipment, upgrades, etc
        public UnitFunctionalData OverridenData { get; private set; }

        public void Initialize(string unitName, UnitFunctionalData overridenData)
        {
            UnitName = unitName;
            OverridenData = overridenData;
        }
    }
}
