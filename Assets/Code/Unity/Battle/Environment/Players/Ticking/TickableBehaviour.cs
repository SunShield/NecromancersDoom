using NDoom.Core.Environment.EventSystem;
using NDoom.Core.Environment.EventSystem.Concrete.Events.Tick;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.Battle.Environment.Players.Ticking
{
	public class TickableBehaviour : ExtendedMonoBehaviour
	{
		protected BattlePlayer Player { get; private set; }
		protected BattlefieldSide Side => Player.Side;
		protected float ReversedRelativeTick => Player.TickState.ReversedRelativeTick;

		public void SetPlayer(BattlePlayer player)
		{
			Player = player;

			if (Player.Side == BattlefieldSide.Left)  EventBus.GetEvent<OnLeftPlayerTickEvent>().SubscribeForGlobal(DoTick);
			if (Player.Side == BattlefieldSide.Right) EventBus.GetEvent<OnRightPlayerTickEvent>().SubscribeForGlobal(DoTick);
		}

		protected sealed override void DestroyInternal()
		{
			DestroyTickableBehaviour();

			if (Player.Side == BattlefieldSide.Left)  EventBus.GetEvent<OnLeftPlayerTickEvent>().UnsubscribeFromGlobal(DoTick);
			if (Player.Side == BattlefieldSide.Right) EventBus.GetEvent<OnRightPlayerTickEvent>().UnsubscribeFromGlobal(DoTick);
		}

		private void DoTick(GameEventArgs args) => OnTick();
		protected virtual void OnTick() { }
		protected virtual void InitializeTickableBehaviour() {}
		protected virtual void DestroyTickableBehaviour() {}
	}
}