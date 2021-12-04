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
		[Inject] private UnitFunctionalDataStorage _unitFunctionalDataStorage;
		[Inject] private BattleStructuralDataStorage _battleStructuralDataStorage;

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
		}

		private void LoadFunctionalData()
		{

		}

		private void LoadStructuralData()
		{
			AllData.Battles.ForEach(data => _battleStructuralDataStorage.Add(data.DataName, data.ToStructuralData()));
		}
	}
}