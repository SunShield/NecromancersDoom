using NDoom.Unity.Battle.Entities.Storaging;
using NDoom.Unity.Battle.Mechanics.Skills.Affection;
using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Battles.Mechanics.Tagging;
using NDoom.Unity.Environment.Main;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace NDoom.Unity.Battle.Affection
{
	/// <summary>
	/// Affector behaviours determine specific aspects of what exactly affectors do.
	/// FOR NOW all the affector behaviour will be determined by the same class,
	/// but LATER, I guess, those should be torn into the smaller "aspect-based" components
	/// </summary>
	public abstract class AffectorBehaviour : ExtendedMonoBehaviour
	{
		[Inject] protected AffectorSpawner AffectorSpawner { get; }
		[Inject] protected EntityRegistry Registry { get; }

		public Affector OwnerAffector { get; private set; }
		protected bool IsInitialized { get; private set; }
		protected Rigidbody2D RigidBody { get; private set; }

		protected IReadOnlyDictionary<string, TaggedParameter> Parameters => OwnerAffector.Parameters;
		protected IReadOnlyDictionary<string, Affector> AffectorPrefabs => OwnerAffector.AffectorPrefabs;

		public void Initialize(Affector owner)
        {
			OwnerAffector = owner;
			IsInitialized = true;
			CacheComponents();
			OnBehaviourInitialized();
		}

		private void CacheComponents()
        {
			RigidBody = GetComponent<Rigidbody2D>();
		}

		protected virtual void OnBehaviourInitialized() { }

        public sealed override void UpdateManually()
        {
			if (!IsInitialized) return;

			OnUpdate();
		}

		protected virtual void OnUpdate() { }

        public override void FixedUpdateManually()
        {
			if (!IsInitialized) return;

			OnFixedUpdate();
		}

		protected virtual void OnFixedUpdate() { }
	}
}
