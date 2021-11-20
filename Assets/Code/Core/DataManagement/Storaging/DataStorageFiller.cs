using NDoom.Core.DataManagement.Loading;
using NDoom.Unity.Data;
using Zenject;

namespace NDoom.Core.DataManagement.Storaging
{
	public class DataStorageFiller
	{
		[Inject] private AllDataReferenceHolder _allDataReferenceHolder;
		[Inject] private FunctionalDataStorage _functionalDataStorage;
		[Inject] private LoadedSpawnDataStorage _loadedSpawnDataStorage;

		public void FillStorage()
		{
			FillBattlesData();
			FillUnitsData();
		}

		private void FillBattlesData()
		{
			var battleLoader = new BattleDataLoader();
			var battlesData = battleLoader.LoadData(_allDataReferenceHolder.AllData.Battles);
			_loadedSpawnDataStorage.SetBattleDatas(battlesData.spawningData);
		}

		private void FillUnitsData()
		{
			var unitLoader = new UnitDataLoader();
			var unitsData = unitLoader.LoadData(_allDataReferenceHolder.AllData.Units);
			_functionalDataStorage.SetUnitDatas(unitsData.functionalData);
			_loadedSpawnDataStorage.SetUnitDatas(unitsData.spawningData);
		}
	}
}