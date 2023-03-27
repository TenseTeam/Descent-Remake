namespace ProjectDescent.ItemSystem.Items.Ammopacks
{
    using System.Collections;
    using System.Collections.Generic;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using UnityEngine;

    public class ConcussionMissilesPack : MonoBehaviour
    {
        [field: SerializeField]
        public float AmmoQuantity { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ConcussionMissile weap))
            {
                weap.AddAmmunition(AmmoQuantity);
                Destroy(gameObject);
            }
        }
    }
}
