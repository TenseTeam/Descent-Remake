
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;


    public class UnlockHomingMissiles : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HomingMissile weap))
            {
                weap.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}