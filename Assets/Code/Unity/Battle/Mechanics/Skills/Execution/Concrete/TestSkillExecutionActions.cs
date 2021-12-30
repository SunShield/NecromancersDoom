using System.Collections;
using NDoom.Unity.Environment.Debugging;
using UnityEngine;

namespace NDoom.Unity.Battles.Mechanics.Skills.Execution.Concrete
{
	public class TestSkillExecutionActions : SkillExecutionActions
	{
		protected override IEnumerator ExecuteInternal()
		{
			yield return new WaitForSeconds(1f);
			GameDebugger.Log("TEST", Parameters["TestParameter"].InnerValue);
		}
	}
}