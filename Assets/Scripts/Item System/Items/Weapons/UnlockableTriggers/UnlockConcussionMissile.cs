
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;


    public class UnlockConcussionMissile : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ConcussionMissile weap))
            {
                weap.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}