using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NDoom.Unity.Environment.Debugging
{
	[CreateAssetMenu(fileName = "Debug Ruleset", menuName = "ScriptableObjects/Debug Ruleset", order = 0)]
	public class GameDebugRuleset : SerializedScriptableObject
	{
		public bool _allDebuggingEnabled;
		public bool _gameDebuggingEnabled;

		public List<GameDebugContext> _allowedContexts;
	}
}
