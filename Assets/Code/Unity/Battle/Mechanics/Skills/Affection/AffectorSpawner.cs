using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Mechanics.Skills.Execution;
using NDoom.Unity.Environment.Main;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Mechanics.Skills.Affection
{
    public class AffectorSpawner : ExtendedMonoBehaviour
    {
        [SerializeField] private Transform _affectorsOrigin;

        [Inject] private DiContainer _container;

        public Affector SpawnAffector(SkillExecutionActions actions, Affector prefab)
        {
            var affector = _container.InstantiatePrefab(prefab).GetComponent<Affector>();
            affector.Initialize(actions);
            affector.transform.parent = _affectorsOrigin;
            return affector;
        }
    }
}
