using NDoom.Unity.Battle.Affection;
using NDoom.Unity.Service.Extensions;
using UnityEngine;

namespace NDoom.Unity.Battle.Mechanics.Skills.Affection.Behaviours.Concrete
{
    public class TestAffectorBehaviour : AffectorBehaviour
    {
        private Vector3 _direction = Vector3.right;

        protected override void OnBehaviourInitialized()
        {
            DetermineFlyDirection();
        }

        private void DetermineFlyDirection()
        {
            var side = OwnerAffector.SkillActions.OwnerSkill.HolderUnit.Tile.Battlefield.Side;
            var oppositeSide = side.Opposite();

            var oppositeUnits = Registry.Units[oppositeSide];
            if (oppositeUnits.Count == 0) return;

            var randomIndex = Random.Range(0, oppositeUnits.Count);
            var target = oppositeUnits[randomIndex];
            var targetPos = target.transform.position;
            _direction = targetPos - OwnerAffector.SkillActions.OwnerSkill.transform.position;
        }

        protected override void OnFixedUpdate()
        {
            RigidBody.MovePosition(transform.position + _direction * Time.fixedDeltaTime * (Parameters["Speed"].Value.FinalValue / 100f) * TickMultiplier);
        }
    }
}
