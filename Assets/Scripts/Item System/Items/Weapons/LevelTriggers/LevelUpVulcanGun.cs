
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;

    public class LevelUpVulcanGun : MonoBehaviour
    {
        [field: SerializeField]
        public uint LevelsToIncrease { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out VulcanGun weap))
            {
                if (weap.enabled)
                    weap.IncreaseLevel(LevelsToIncrease);
                else
                    weap.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}