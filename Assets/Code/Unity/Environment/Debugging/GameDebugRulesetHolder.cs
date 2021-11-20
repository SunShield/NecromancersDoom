using System;
using UnityEngine;

namespace NDoom.Unity.Environment.Debugging
{
	public class GameDebugRulesetHolder : MonoBehaviour
	{
		[SerializeField] private GameDebugRuleset _debugRuleset;
		public GameDebugRuleset debugRuleset => _debugRuleset;

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
