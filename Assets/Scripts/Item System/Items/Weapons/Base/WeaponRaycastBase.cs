namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using Extension.Audio;
    using UnityEngine;
    using ProjectDescent.EntitySystem.Interfaces;

    public class WeaponRaycastBase : WeaponBase
    {
        [field: SerializeField, Header("Raycast")]
        public float RaycastShootRange { get; set; }

        [field: SerializeField]
        public LayerMask RayShootableMask { get; set; }

        [field: SerializeField, Header("VFX")]
        public GameObject VFXOnHit { get; set; }

        protected override void BulletGeneration()
        {
            foreach (Transform barrel in BarrelsPoints)
            {
#if DEBUG
                Debug.DrawRay(barrel.position, barrel.forward * RaycastShootRange);
#endif
                OnShootAudio.PlayClipAtPoint(barrel.transform.position);
                if (Physics.Raycast(barrel.position, barrel.forward, out RaycastHit hit, RaycastShootRange, RayShootableMask))
                {
                    Instantiate(VFXOnHit, hit.point, Quaternion.identity);
                    if (hit.transform.TryGetComponent(out IVulnerable ent))
                    {
                        ent.TakeDamage(Damage.Random());
                    }
                }
            }
        }

        public override void SelectWeapon()
        {
        }

        public override void DeselectWeapon()
        {
        }
    }
}