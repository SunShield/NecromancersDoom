using NDoom.Core.Environment.EventSystem.Concrete.Events.Tick;
using NDoom.Core.EventSystem.Concrete.Args;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.Battle.Environment.Players.Ticking
{
	public class TickableBehaviour : ExtendedMonoBehaviour
	{
		protected BattlePlayer Player { get; private set; }
		protected BattlefieldSide Side => Player.Side;
		protected float ReversedRelativeTick => Player.TickState.ReversedRelativeTick;

		public void SetPlayer(BattlePlayer player) => Player = player;

		protected sealed override void InitializeInternal()
		{
			EventBus.GetEvent<OnPlayerTickEvent>().SubscribeForGlobal(OnPlayerTick);
			InitializeTickableBehaviour();
		}

		private void OnPlayerTick(PlayerTickArgs args)
		{
			if (Player.Side != args.PlayerSide) return;

			OnTick();
		}

		protected override void DestroyInternal()
		{
			EventBus.GetEvent<OnPlayerTickEvent>().UnsubscribeFromGlobal(OnPlayerTick);
			DestroyTickableBehaviour();
		}

		protected virtual void OnTick() { }
		protected virtual void InitializeTickableBehaviour() {}
		protected virtual void DestroyTickableBehaviour() {}
	}
}