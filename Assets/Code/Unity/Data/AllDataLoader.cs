using NDoom.Unity.Battles.Entities.Data.Storaging;
using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Data
{
	public class AllDataLoader : ExtendedMonoBehaviour
	{
		[Inject] private AllDataReferenceHolder _allDataReferenceHolder;
		[Inject] private BattleGraphicalDataStorage _battleGraphicalDataStorage;

		public void LoadAllData()
		{

		}
	}
}