using Sirenix.OdinInspector;

namespace NDoom.Unity.ScriptableObjects.Data.Unit
{
	public class UnitData : NamedData
	{
		private const string MainVerticalGroupName = "Unit";
		private const string BasicUnitDataFoldoutGroupName = MainVerticalGroupName + "/Basic Data";
		private const string BasicDataHorizontalGroupName = BasicUnitDataFoldoutGroupName + "/Horizontal";
		private const string BasicDataVerticalGroupName = BasicDataHorizontalGroupName + "/Vertical";
		
		public override string DataName => Name;

		[BoxGroup(MainVerticalGroupName)][FoldoutGroup(BasicUnitDataFoldoutGroupName)][HorizontalGroup(BasicDataHorizontalGroupName, Width = 130)]
		[HideLabel][PreviewField(ObjectFieldAlignment.Left, Height = 128f)]
		public Battles.Entities.Concrete.Unit Prefab;

		[VerticalGroup(BasicDataVerticalGroupName)]
		[LabelWidth(45)]
		public string Name;
	}
}