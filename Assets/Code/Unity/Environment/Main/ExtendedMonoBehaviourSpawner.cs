using UnityEngine;
using Zenject;

namespace NDoom.Unity.Environment.Main
{
    public class ExtendedMonoBehaviourSpawner
    {
        [Inject] private DiContainer _container;

        public TBehaviour SpawnMonoBehaviour<TBehaviour>(TBehaviour prefab)
            where TBehaviour : ExtendedMonoBehaviour
        {
            var behaviour = _container.InstantiatePrefab(prefab);
            return behaviour.GetComponent<TBehaviour>();
        }

        public TBehaviour SpawnMonoBehaviour<TBehaviour>(TBehaviour prefab, Vector3 position, Quaternion rotation, Transform parent)
           where TBehaviour : ExtendedMonoBehaviour
        {
            var behaviour = GameObject.Instantiate(prefab, position, rotation, parent);
            _container.Inject(behaviour);
            return behaviour;
        }
    }
}
