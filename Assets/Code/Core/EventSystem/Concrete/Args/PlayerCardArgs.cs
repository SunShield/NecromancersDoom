using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Battle.Environment.Players.Cards;

namespace NDoom.Core.EventSystem.Concrete.Args
{
    public class PlayerCardArgs : GameEventArgs
    {
        public PlayerCard Card { get; private set; }

        public PlayerCardArgs(PlayerCard card) => Card = card;
    }
}
