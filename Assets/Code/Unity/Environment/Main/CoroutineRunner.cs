using System.Collections;

namespace NDoom.Unity.Environment.Main
{
	public class CoroutineRunner : ExtendedMonoBehaviour
	{
		public void DoStartCoroutine(IEnumerator routine)
		{
			StartCoroutine(routine);
		}

		public void InterruptCoroutine(IEnumerator routine)
		{
			StopCoroutine(routine);
		}
	}
}