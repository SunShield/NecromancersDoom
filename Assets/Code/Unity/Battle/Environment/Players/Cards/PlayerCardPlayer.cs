using NDoom.Core.Environment.EventSystem;
using NDoom.Core.EventSystem.Concrete.Args;
using NDoom.Core.EventSystem.Concrete.Events.Cards;
using NDoom.Unity.Environment.Main;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Cards
{
    public class PlayerCardPlayer : ExtendedMonoBehaviour
    {
        [Inject] private EventBus _eventBus;

        public void Initialize()
        {
            _eventBus.GetEvent<OnStartPlayerCardPlaying>().SubscribeForGlobal(OnPlayerCardStartPlaying);
        }

        private void OnPlayerCardStartPlaying(PlayerCardArgs args)
        {
            Debug.Log("Playing card!");
            FinishCardPlaying(args.Card);
        }

        private void FinishCardPlaying(PlayerCard card) => _eventBus.GetEvent<OnFinishPlayerCardPlaying>().InvokeForGlobal(new PlayerCardArgs(card));
    }
}
