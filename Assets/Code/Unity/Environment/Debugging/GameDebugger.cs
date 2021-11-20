using System.Collections.Generic;
using UnityEngine;

namespace NDoom.Unity.Environment.Debugging
{
	public static class GameDebugger
	{
		private const string DEFAULT_COLOR = "7d5132";
		private static readonly Dictionary<GameDebugContext, string> _colorizingStringsDictionary =
			new Dictionary<GameDebugContext, string>()
			{
				{ GameDebugContext.PREPARATION, "e38512" },
			};

		private static HashSet<GameDebugContext> _debuggingContexts;

		private static GameDebugRuleset _debugRuleset;
		private static bool gameDebugEnabled => _debugRuleset._gameDebuggingEnabled;
		private static bool _isInitialized;

		public static void Log(string context, object debugMessage)
			=> LogInternal(context, DEFAULT_COLOR, debugMessage);

		public static void Log(string context, string color, object _debugMessage) 
			=> LogInternal(context, color, _debugMessage);

		public static void Log(GameDebugContext context, object debugMessage)
		{
			InitializeIfNeeded();

			if (!IsContextDebuggable(context)) return;

			LogInternal(context.ToString(), GetContextColor(context), debugMessage);
		}

		private static void InitializeIfNeeded()
		{
			if (_isInitialized) return;

			FindDebugRuleset();
			SetAllDebuggingEnabled();
			GetDebuggingContexts();

			_isInitialized = true;
		}

		private static void FindDebugRuleset()
		{
			var rulesetHolder = GameObject.FindObjectOfType<GameDebugRulesetHolder>();
			_debugRuleset = rulesetHolder.debugRuleset;
		}

		private static void SetAllDebuggingEnabled() => Debug.unityLogger.logEnabled = _debugRuleset._allDebuggingEnabled;

		private static void GetDebuggingContexts() =>
			_debuggingContexts = new HashSet<GameDebugContext>(_debugRuleset._allowedContexts);

		private static bool IsContextDebuggable(GameDebugContext context)
			=> _debuggingContexts.Contains(context);

		private static string GetContextColor(GameDebugContext context) => _colorizingStringsDictionary[context];

		private static void LogInternal(string context, string color, object debugMessage)
		{
			InitializeIfNeeded();

			if (!gameDebugEnabled) return;

			var internalMessage = BuildInternalLogMessage(context, color, debugMessage);
			Debug.Log(internalMessage);
		}

		private static string BuildInternalLogMessage(string context, string color, object debugMessage)
			=> $"[<color=#{color}ff>{context.ToUpper()}</color>]: {debugMessage}";
	}
}
