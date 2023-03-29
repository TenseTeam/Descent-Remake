namespace ProjectDescent.ItemSystem.Items.Ammopacks
{
    using System.Collections;
    using System.Collections.Generic;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using UnityEngine;

    public class HomingMissilesPack : MonoBehaviour
    {
        [field: SerializeField]
        public float AmmoQuantity { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HomingMissile weap) && weap.enabled)
            {
                weap.AddAmmunition(AmmoQuantity);
                Destroy(gameObject);
            }
        }
    }
}
