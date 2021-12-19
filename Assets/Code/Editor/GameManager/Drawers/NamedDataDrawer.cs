using NDoom.Unity.ScriptableObjects.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace NDoom.Editor.GameManager.Drawers
{
	public class NamedDataDrawer<TData>
		where TData : SerializedScriptableObject
	{
		[InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)][SerializeField] 
		private TData _selected;

		[LabelWidth(150)][PropertyOrder(-1)][BoxGroup("Create New")][HorizontalGroup("Create New/Horizontal")][SerializeField] 
		private string _newObjectName;
		private string _newObjectPath;

		private string SelectedObjectPath => AssetDatabase.GetAssetPath(_selected);
		private AllData _allData;

		public void Initialize()
		{
			_allData = AssetDatabase.LoadAssetAtPath<AllData>(GameManagerConstants.AllDataPath);
		}

		[HorizontalGroup("Create New/Horizontal")][GUIColor(0.7f, 0.7f, 1f)][Button]
		public void CreateNew()
		{
			if (string.IsNullOrEmpty(_newObjectName)) return;
			if (string.IsNullOrEmpty(_newObjectPath)) return;

			var newItem = ScriptableObject.CreateInstance<TData>();
			newItem.name = _newObjectName;
			_allData.Add(newItem);
			AssetDatabase.CreateAsset(newItem, $"{_newObjectPath}\\{_newObjectName}.asset");
			AssetDatabase.SaveAssets();

			_newObjectName = string.Empty;
		}

		[HorizontalGroup("Create New/Horizontal")][GUIColor(1f, 0.7f, 0.7f)][Button]
		public void Delete()
		{
			if (_selected == null) return;
			_allData.Remove(_selected);
			AssetDatabase.DeleteAsset(SelectedObjectPath);
			AssetDatabase.SaveAssets();
		}

		public void SetSelected(object item)
		{
			var itemCoverted = item as TData;
			if (itemCoverted == null) return;
			_selected = itemCoverted;
		}

		public void SetPath(string path) => _newObjectPath = path;

	}
}