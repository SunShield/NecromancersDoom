using NDoom.Unity.Battles.Affection;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Skills
{
	public class SkillAffectorData
	{
		private const string BaseVerticalGroup = "Prefab";
		private const string BaseHorizontalGroup = BaseVerticalGroup + "/Horizontal";
		private const string NameVerticalGroup = "Name";

		[VerticalGroup(BaseVerticalGroup)]
		[TableColumnWidth(66, Resizable = false)]
		[PreviewField(Height = 64, Alignment = ObjectFieldAlignment.Center)]
		[HideLabel]
		public Affector Prefab;

		[VerticalGroup(NameVerticalGroup)]
		[HideLabel]
		public string Name;
	}
}