using NDoom.Unity.Battles.Affection;
using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Skills
{
	public class SkillAffectorData
	{
		private const string BaseVerticalGroup = "Prefab";
		private const string BaseHorizontalGroup = BaseVerticalGroup + "/Horizontal";
		private const string NameVerticalGroup = "Name";

		[VerticalGroup(BaseVerticalGroup)]
		[TableColumnWidth(130, Resizable = false)]
		[PreviewField(Height = 128, Alignment = ObjectFieldAlignment.Center)]
		[HideLabel]
		public Affector Prefab;

		[VerticalGroup(NameVerticalGroup)]
		[HideLabel]
		public string Name;
	}
}