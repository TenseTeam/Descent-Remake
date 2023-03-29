namespace ProjectDescent.ItemSystem.Items.Ammopacks
{
    using System.Collections;
    using System.Collections.Generic;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using UnityEngine;

    public class LaserRechargeOnTriggerStay : MonoBehaviour
    {
        [field: SerializeField]
        public float RechargeVelocity { get; set; }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out LaserCannon weap) && weap.enabled)
            {
                weap.AddAmmunition(RechargeVelocity * Time.deltaTime);
            }
        }
    }
}
