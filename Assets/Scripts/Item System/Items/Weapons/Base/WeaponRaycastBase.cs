namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using UnityEngine;

    public class WeaponRaycastBase : WeaponBase
    {
        [field: SerializeField, Header("Raycast")]
        public float RaycastShootRange { get; set; }

        [field: SerializeField]
        public LayerMask RayShootableMask { get; set; }

        protected override void BulletGeneration()
        {
            foreach (Transform barrel in BarrelsPoints)
            {
                Debug.DrawRay(barrel.position, barrel.forward * RaycastShootRange);
                if(Physics.Raycast(barrel.position, barrel.forward, out RaycastHit hit, RaycastShootRange, RayShootableMask))
                {
                    //if(hit.transform.TryGetComponent<>) Hit method on IDamageable interface
                }
            }
        }
    }
}