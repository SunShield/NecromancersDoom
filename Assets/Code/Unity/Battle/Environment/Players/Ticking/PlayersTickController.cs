using System;
using NDoom.Core.Environment.EventSystem;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using NDoom.Core.Environment.EventSystem.Concrete.Events.Tick;
using NDoom.Core.EventSystem.Concrete.Args;
using NDoom.Unity.Battles.Entities.Data.Concrete.Positioning;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Environment.Players.Ticking
{
	/// <summary>
	/// Tick is one of the main game mechanics
	/// Each player has a payload float value called "tick". Tick represents something like "time for certain things to happen".
	/// All the timed stuff in game is calculated in ticks. So, if both players control the same units
	/// and first player's tick is two times smaller than second one's,
	/// that player's unit will do everything  twice as fast then second player's unit.
	/// Tick affects:
	/// 1. Skills preparation, delay and execution times
	/// 2. Speed of affectors related to player.
	/// 3. Speed of different card actions (movement to hand, etc)
	/// 4. Delay between actions of certain affectors (for example, flaming ground will do damage faster/slower depending on player's tick)
	/// Default tick is 500 ms.
	/// ***
	/// Sometimes tick can change during the game. If this happens, current tick remains the same length, and the next one shrinks of widens.
	/// </summary>
	public class PlayersTickController : ExtendedMonoBehaviour
	{
		private readonly Dictionary<BattlefieldSide, PlayerTickState> _playerTickStates = new Dictionary<BattlefieldSide, PlayerTickState>()
		{
			{ BattlefieldSide.Left,  null },
			{ BattlefieldSide.Right, null },
		};
		public IReadOnlyDictionary<BattlefieldSide, PlayerTickState> PlayerTickStates => _playerTickStates;

		[Inject] private EventBus _eventBus;
		
		private OnPlayerTickEvent _storedEvent;
		private PlayerTickArgs _storedArgs = new PlayerTickArgs();
		private bool _isInitialized;

		public void Initialize(BattlePlayer left, BattlePlayer right)
		{
			_playerTickStates[BattlefieldSide.Left]  = new PlayerTickState(left);
			_playerTickStates[BattlefieldSide.Right] = new PlayerTickState(right);
			_storedEvent = _eventBus.GetEvent<OnPlayerTickEvent>();
			_isInitialized = true;
		}

		public override void UpdateManually()
		{
			if (!_isInitialized) return;

			UpatePlayers();
		}

		private void UpatePlayers() => _playerTickStates.ForEach(pair => UpdatePlayer(pair.Key));

		private void UpdatePlayer(BattlefieldSide side)
		{
			var state = _playerTickStates[side];
			if (state.TickIsFinished)
			{
				FireTickEvent(side);
				state.StartTick();
			}
			state.AdvanceTimer();
		}

		private void FireTickEvent(BattlefieldSide side)
		{
			_storedArgs.PlayerSide = side;
			_storedEvent.InvokeForGlobal(_storedArgs);
		}
	}

	public class PlayerTickState
	{
		private const float SecondsToMsMultiplier = 0.001f;

		private readonly BattlePlayer _player;
		private float _previousTickTimeMs;
		public float _tickTimer;

		public float PreviousTickTime
		{
			get => _player.TickState.PreviousTickTime;
			set => _player.TickState.PreviousTickTime = value;
		}

		public float TickTime => _player.TickState.TickTime.FinalValue;

		public float TickTimeMs => TickTime * SecondsToMsMultiplier;
		public bool TickIsFinished => _tickTimer == 0f;
		public float TickProgress => 1 - _tickTimer / PreviousTickTime;

		public PlayerTickState(BattlePlayer player) => _player = player;

		public void StartTick()
		{
			PreviousTickTime = TickTime;
			_previousTickTimeMs = TickTimeMs;
			_tickTimer = _previousTickTimeMs;
		}

		public void AdvanceTimer() => _tickTimer = MathF.Max(_tickTimer - Time.deltaTime, 0f);
	}
}