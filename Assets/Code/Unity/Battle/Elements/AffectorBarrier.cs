using NDoom.Unity.Battles.Affection;
using NDoom.Unity.Environment.Main;

namespace NDoom.Unity.Battle.Elements
{
    public class AffectorBarrier : ExtendedMonoBehaviour
    {
        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            if (collision.GetComponent<Affector>() == null) return;

            Destroy(collision.gameObject);
        }
    }
}
