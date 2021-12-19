using System.Linq;
using NDoom.Unity.Battles.Entities.Data.Concrete;
using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.ScriptableObjects.Data.Single;
using Sirenix.Utilities;
using Zenject;

namespace NDoom.Unity.Data
{
	public class AllDataLoader
	{
		[Inject] private AllDataReferenceHolder _allDataReferenceHolder;

		[Inject] private BattleGraphicalDataStorage _battleGraphicalDataStorage;
		[Inject] private UnitGraphicalDataStorage _unitGraphicalDataStorage;
		[Inject] private SkillGraphicalDataStorage _skillGraphicalDataStorage;

		[Inject] private UnitFunctionalDataStorage _unitFunctionalDataStorage;
		[Inject] private SkillFunctionalDataStorage _skillFunctionalDataStorage;

		[Inject] private BattleStructuralDataStorage _battleStructuralDataStorage;
		[Inject] private UnitStructuralDataStorage _unitStructuralDataStorage;

		[Inject] private TagsData TagsData;

		private AllData AllData => _allDataReferenceHolder.AllData;

		public void LoadAllData()
		{
			LoadGraphicalData();
			LoadFunctionalData();
			LoadStructuralData();
			LoadTagsData();
		}

		private void LoadGraphicalData()
		{
			AllData.Battles.ForEach(data => _battleGraphicalDataStorage.Add(data.DataName, data.ToGraphicalData()));
			AllData.Units.ForEach(data => _unitGraphicalDataStorage.Add(data.DataName, data.ToGraphicalData()));
			AllData.Skills.ForEach(data => _skillGraphicalDataStorage.Add(data.DataName, data.ToGraphicalData()));
		}

		private void LoadFunctionalData()
		{
			AllData.Units.ForEach(data => _unitFunctionalDataStorage.Add(data.DataName, data.ToFunctionalData()));
			AllData.Skills.ForEach(data => _skillFunctionalDataStorage.Add(data.DataName, data.ToFunctionalData()));
		}

		private void LoadStructuralData()
		{
			AllData.Battles.ForEach(data => _battleStructuralDataStorage.Add(data.DataName, data.ToStructuralData()));
			AllData.Units.ForEach(data => _unitStructuralDataStorage.Add(data.DataName, data.ToStructuralData()));
		}

		private void LoadTagsData()
		{
			//var dataTagsDict = AllData.TagsData.Tags.ToDictionary(tag => tag.Name);
			//TagsData.Tags = dataTagsDict.Keys.Select(tagName => new ValueTag(tagName)).ToDictionary(tag => tag.Name);
			//TagsData.Tags.Keys.ForEach(
			//	tag => dataTagsDict[tag].Ancestors.ForEach(
			//		ancestor => TagsData.Tags[tag].Ancestors.Add(TagsData.Tags[ancestor])));
			//var t = 5;
		}
	}
}