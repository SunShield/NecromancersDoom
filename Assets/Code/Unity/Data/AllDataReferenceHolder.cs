using NDoom.Unity.Environment.Main;
using NDoom.Unity.ScriptableObjects.Data;
using UnityEngine;

namespace NDoom.Unity.Data
{
	public class AllDataReferenceHolder : ExtendedMonoBehaviour
	{
		[SerializeField] private AllData _allData;
		public AllData AllData => _allData;
	}
}