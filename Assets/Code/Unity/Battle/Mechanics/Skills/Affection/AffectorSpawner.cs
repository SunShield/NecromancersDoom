using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Mechanics.Skills.Execution;
using Zenject;

namespace NDoom.Unity.Battle.Mechanics.Skills.Affection
{
    public class AffectorSpawner
    {
        [Inject] private DiContainer _container;

        public Affector SpawnAffector(SkillExecutionActions actions, Affector prefab)
        {
            var affector = _container.InstantiatePrefab(prefab).GetComponent<Affector>();
            affector.Initialize(actions);
            return affector;
        }
    }
}
