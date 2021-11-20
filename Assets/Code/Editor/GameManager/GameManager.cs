using System.Collections.Generic;
using NDoom.Editor.GameManager.Tabs;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace NDoom.Editor.GameManager
{
	public class GameManager : OdinMenuEditorWindow
	{
		private readonly Dictionary<GameManagerTab, GameManagerTabDrawer> _tabDrawers = new Dictionary<GameManagerTab, GameManagerTabDrawer>()
		{
			{ GameManagerTab.Main,    new GameManagerMainTabDrawer() },
			{ GameManagerTab.Battles, new GameManagerBattlesTabDrawer() },
			{ GameManagerTab.Skills,  new GameManagerSkillsTabDrawer() },
			{ GameManagerTab.Units,   new GameManagerUnitsTabDrawer() },
			{ GameManagerTab.Effects, new GameManagerEffectsTabDrawer() },
		};

		[LabelText("Current Tab")][LabelWidth(100)][EnumToggleButtons][ShowInInspector]
		[OnValueChanged("SetTreeDirty")]
		private GameManagerTab _currentTab;
		private int _lastTargetIndex;
		private bool _treeDirty;

		private GameManagerTabDrawer CurrentDrawer => _tabDrawers[_currentTab];

		[MenuItem("Tools/GameManager")]
		public static void Open() => GetWindow<GameManager>().Show();

		protected override void Initialize()
		{
			_tabDrawers.Values.ForEach(drawer => drawer.Initialize(this));
		}

		protected override void OnGUI()
		{
			if (_treeDirty && Event.current.type == EventType.Layout)
			{
				ForceMenuTreeRebuild();
				_treeDirty = false;
			}

			SirenixEditorGUI.Title("Game Manager", "", TextAlignment.Center, true);
			EditorGUILayout.Space();
			DrawLastEditor();
			EditorGUILayout.Space();
			base.OnGUI();
		}

		protected override void DrawEditors()
		{
			CurrentDrawer.OnDrawEditors();
			DrawEditor((int)_currentTab);
		}

		protected override OdinMenuTree BuildMenuTree()
		{
			var tree = new OdinMenuTree();
			if(CurrentDrawer.HasMenuTree) CurrentDrawer.OnMenuTree(tree);

			return tree;
		}

		protected override IEnumerable<object> GetTargets()
		{
			var targets = new List<object>();
			for (int i = 0; i < _tabDrawers.Count; i++)
			{
				targets.Add(_tabDrawers[(GameManagerTab)i].DrawableContent);
			}
			targets.Add(base.GetTarget());
			_lastTargetIndex = targets.Count - 1;
			return targets;
		}

		protected override void DrawMenu()
		{
			if(CurrentDrawer.HasMenuTree) base.DrawMenu();
		}

		private void SetTreeDirty() => _treeDirty = true;
		private void DrawLastEditor() => DrawEditor(_lastTargetIndex);
	}

}
