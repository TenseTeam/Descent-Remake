namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using ProjectDescent.ItemSystem.Items.Bullets;
    using UnityEngine;

    public class WeaponPhysicBase : WeaponBase
    {
        [field: SerializeField, Header("Bullet")]
        public GameObject BulletPrefab { get; set; }
        [field: SerializeField]
        public float BulletSpeed { get; set; }

        protected override void OnShoot()
        {
            foreach (Transform barrel in BarrelsPoints)
            {
                if (Instantiate(BulletPrefab, barrel.transform.position, barrel.transform.rotation).TryGetComponent(out Bullet bull))
                {
                    bull.Init(Damage.Random(), BulletSpeed);
                }
            }
        }
    }
}