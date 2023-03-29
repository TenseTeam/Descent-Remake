
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;


    public class UnlockVulcanGun : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out VulcanGun weap))
            {
                weap.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}