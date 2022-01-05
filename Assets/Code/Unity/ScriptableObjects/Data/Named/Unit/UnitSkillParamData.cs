using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Named.Unit
{
	public class UnitSkillParamData
	{
		private const string NameVerticalGroup = "Name";
		private const string ValueVerticalGroup = "Value";

		[VerticalGroup(NameVerticalGroup)]
		[TableColumnWidth(120, Resizable = false)]
		[ReadOnly]
		[HideLabel]
		public string Name;

		[VerticalGroup(ValueVerticalGroup)]
		[HideLabel]
		public float Value;

		public UnitSkillParamData(string name, float value)
		{
			Name = name;
			Value = value;
		}
	}
}