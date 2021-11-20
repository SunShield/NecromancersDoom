using System.Collections.Generic;
using NDoom.Core.DataManagement.DataStructure.Spawn;

namespace NDoom.Core.DataManagement.Storaging
{
	public class LoadedSpawnDataStorage
	{
		private Dictionary<string, BattleLoadedSpawnData> _battleDatas = new Dictionary<string, BattleLoadedSpawnData>();
		private Dictionary<string, UnitLoadedSpawnData> _unitDatas = new Dictionary<string, UnitLoadedSpawnData>();
		public IReadOnlyDictionary<string, BattleLoadedSpawnData> BattleDatas => _battleDatas;
		public IReadOnlyDictionary<string, UnitLoadedSpawnData> UnitDatas => _unitDatas;

		public void SetBattleDatas(Dictionary<string, BattleLoadedSpawnData> datas)
		{
			_battleDatas = datas;
		}

		public void SetUnitDatas(Dictionary<string, UnitLoadedSpawnData> datas)
		{
			_unitDatas = datas;
		}
	}
}