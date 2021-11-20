using System;
using System.Collections.Generic;

namespace NDoom.Core.Environment.EventSystem
{
	public class EventBus
	{
		private readonly Dictionary<Type, IGameEvent> m_typesToEventsMap = new Dictionary<Type, IGameEvent>();

		public TEventType GetEvent<TEventType>()
			where TEventType : IGameEvent, new()
		{
			var type = typeof(TEventType);

			if(!m_typesToEventsMap.ContainsKey(type))
			{
				var newEvent = new TEventType();
				m_typesToEventsMap.Add(type, newEvent);
			}

			return (TEventType)m_typesToEventsMap[type];
		}
	}
}
