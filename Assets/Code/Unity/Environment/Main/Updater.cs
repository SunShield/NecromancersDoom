using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Environment.Main
{
	public class Updater : MonoBehaviour
	{
		private readonly Dictionary<int, ExtendedMonoBehaviour> _behaviours = new Dictionary<int, ExtendedMonoBehaviour>();
		private readonly Dictionary<int, ExtendedMonoBehaviour> _registredBehaviours = new Dictionary<int, ExtendedMonoBehaviour>();
		private readonly List<int> _removedIds = new List<int>();

		public void RegisterUpdatebleBehaviour(ExtendedMonoBehaviour newBehaviour)
		{
			var id = newBehaviour.GetInstanceID();
			if (_behaviours.ContainsKey(id) || _registredBehaviours.ContainsKey(id)) return;

			// we can't immediately add new behaviours to the dictionary, because new behaviour can be added from UpdateManually of the another behaviour - 
			// this will modify the collection during Foreach which is not allowed.
			_registredBehaviours.Add(id, newBehaviour);
		}

		private void Update()
		{
			AddRegistredBehaviours();
			UpdateBehavioursInternal();
			RemoveDestroyedBehaviours();
		}

        private void FixedUpdate()
        {
			AddRegistredBehaviours();
			FixedUpdateManually();
			RemoveDestroyedBehaviours();
		}

        private void AddRegistredBehaviours()
		{
			if (_registredBehaviours.Count == 0) return;

			foreach (var id in _registredBehaviours.Keys)
			{
				var behaviour = _registredBehaviours[id];
				if (behaviour == null) continue; // to handle rare but possible case where one UpdateManually registres the behaviour and another one destroys it.

				_behaviours.Add(id, behaviour);
			}
			_registredBehaviours.Clear();
		}

		private void UpdateBehavioursInternal()
		{
			foreach (var id in _behaviours.Keys)
			{
				var behaviour = _behaviours[id];
				if (behaviour == null)
					MarkBehaviourAsRemoved(id);
				else
				{
					if (behaviour.gameObject.activeSelf) // if GO is inactive, it shouldn't get updated
						behaviour.UpdateManually();
				}
			}
		}

		private void FixedUpdateManually()
        {
			foreach (var id in _behaviours.Keys)
			{
				var behaviour = _behaviours[id];
				if (behaviour == null)
					MarkBehaviourAsRemoved(id);
				else
				{
					if (behaviour.gameObject.activeSelf) // if GO is inactive, it shouldn't get updated
						behaviour.FixedUpdateManually();
				}
			}
		}

		private void MarkBehaviourAsRemoved(int id) => _removedIds.Add(id);

		private void RemoveDestroyedBehaviours()
		{
			if (_removedIds.Count == 0) return;

			for (int i = _removedIds.Count - 1; i >= 0; i--)
			{
				_behaviours.Remove(_removedIds[i]);
				_removedIds.RemoveAt(i);
			}
		}
	}
}
