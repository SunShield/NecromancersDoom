using System;
using System.Collections.Generic;

namespace NDoom.Core.Environment.EventSystem
{
	public class GameEvent<TArgs> : IGameEvent
		where TArgs : GameEventArgs
	{
		private readonly HashSet<Action<TArgs>> m_globalSubscribedActions = new HashSet<Action<TArgs>>();
		private readonly HashSet<Action<TArgs>> m_subscribtionsDuringInvoke = new HashSet<Action<TArgs>>();
		private readonly HashSet<Action<TArgs>> m_unsubscriptionsDuringInvoke = new HashSet<Action<TArgs>>();
		private bool m_isInvokingNow;

		public void SubscribeForGlobal(Action<TArgs> _action)
		{
			if (!m_isInvokingNow)
				m_globalSubscribedActions.Add(_action);
			else
				m_subscribtionsDuringInvoke.Add(_action);
		}

		public void UnsubscribeFromGlobal(Action<TArgs> _action)
		{
			if (!m_isInvokingNow)
				m_globalSubscribedActions.Remove(_action);
			else
				m_unsubscriptionsDuringInvoke.Add(_action);
		}

		public void InvokeForGlobal(TArgs _args)
		{
			m_isInvokingNow = true;

			foreach(var subscribedAction in m_globalSubscribedActions)
			{
				// Если мы удалили обработчик во время инвоука, не дёргаем его
				if(!m_unsubscriptionsDuringInvoke.Contains(subscribedAction)) 
					subscribedAction.Invoke(_args);
			}

			foreach (var subscribedAction in m_subscribtionsDuringInvoke)
			{
				if(!m_unsubscriptionsDuringInvoke.Contains(subscribedAction)) 
					subscribedAction.Invoke(_args);
			}

			m_isInvokingNow = false;
			OnFinishInvoke();
		}

		private void OnFinishInvoke()
		{
			RemoveUnsubscribedDuringInvokeActions();
			AddSubscribedDuringInvokeActions();
		}

		private void RemoveUnsubscribedDuringInvokeActions()
		{
			foreach (var action in m_unsubscriptionsDuringInvoke)
			{
				m_globalSubscribedActions.Remove(action);
			}

			m_unsubscriptionsDuringInvoke.Clear();
		}

		private void AddSubscribedDuringInvokeActions()
		{
			foreach (var action in m_subscribtionsDuringInvoke)
			{
				m_globalSubscribedActions.Add(action);
			}

			m_subscribtionsDuringInvoke.Clear();
		}
	}
}
