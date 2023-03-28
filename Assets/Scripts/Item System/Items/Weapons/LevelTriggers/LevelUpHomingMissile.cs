
namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using UnityEngine;
    using ItemSystem.Items.Bullets;


    public class LevelUpHomingMissile : MonoBehaviour
    {
        [field: SerializeField]
        public uint LevelsToIncrease { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HomingMissile weap))
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