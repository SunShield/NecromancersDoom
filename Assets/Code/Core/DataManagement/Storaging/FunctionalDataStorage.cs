using System.Collections.Generic;
using NDoom.Core.DataManagement.DataStructure.Functional;

namespace NDoom.Core.DataManagement.Storaging
{
	public class FunctionalDataStorage
	{
		private Dictionary<string, UnitFunctionalData> _unitDatas = new Dictionary<string, UnitFunctionalData>();
		public IReadOnlyDictionary<string, UnitFunctionalData> UnitDatas => _unitDatas;

		public void SetUnitDatas(Dictionary<string, UnitFunctionalData> datas)
		{
			_unitDatas = datas;
		}
	}
}