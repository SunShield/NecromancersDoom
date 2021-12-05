using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.ScriptableObjects.Data;
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

		private AllData AllData => _allDataReferenceHolder.AllData;

		public void LoadAllData()
		{
			LoadGraphicalData();
			LoadFunctionalData();
			LoadStructuralData();
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
	}
}