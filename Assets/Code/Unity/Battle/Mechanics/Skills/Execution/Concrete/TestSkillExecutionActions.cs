using System.Collections;
using UnityEngine;

namespace NDoom.Unity.Battles.Mechanics.Skills.Execution.Concrete
{
	public class TestSkillExecutionActions : SkillExecutionActions
	{
		protected override IEnumerator ExecuteInternal()
		{
			yield return new WaitForSeconds(0.01f);
			var spawned = AffectorSpawner.SpawnAffector(this, AffectorPrefabs["TestAffector"]);
			spawned.transform.position = OwnerSkill.transform.position;
		}
	}
}