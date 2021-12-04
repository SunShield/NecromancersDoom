using NDoom.Unity.Environment.Main;
using Zenject;

namespace NDoom.Unity.Data
{
	public class AllDataLoader : ExtendedMonoBehaviour
	{
		[Inject] private AllDataReferenceHolder _allDataReferenceHolder;

		public void LoadAllData()
		{

		}
	}
}