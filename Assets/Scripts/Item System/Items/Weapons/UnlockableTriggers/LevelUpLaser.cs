
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;


    public class LevelUpLaser : MonoBehaviour
    {
        [field: SerializeField]
        public uint LevelsToIncrease { get; set; } = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out LaserCannon weap))
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