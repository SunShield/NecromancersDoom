using NDoom.Unity.ScriptableObjects.Data.Single;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace NDoom.Editor.GameManager.Drawers
{
	public abstract class ScriptableObjectDrawer<TScriptableObject>
		where TScriptableObject : SerializedScriptableObject
	{
		[InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
		public TScriptableObject DrawnItem;
		protected AllData AllData;

		public void Initialize()
		{
			AllData = AssetDatabase.LoadAssetAtPath<AllData>(GameManagerConstants.AllDataPath);
		}

		public void SetDrawnItem(string path)
		{
			var asset = LoadAsset(path);
			if (asset == null) asset = CreateAsset(path);
			RegisterAsset(asset);
			DrawnItem = asset;
		}

		private TScriptableObject LoadAsset(string path) => AssetDatabase.LoadAssetAtPath<TScriptableObject>(path);

		private TScriptableObject CreateAsset(string path)
		{
			var instance = ScriptableObject.CreateInstance<TScriptableObject>();
			instance.name = typeof(TScriptableObject).ToString();
			AssetDatabase.CreateAsset(instance, path);
			AssetDatabase.SaveAssets();
			return instance;
		}

		protected abstract void RegisterAsset(TScriptableObject asset);
	}
}