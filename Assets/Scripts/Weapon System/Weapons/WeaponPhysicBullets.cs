namespace ProjectDescent.WeaponSystem.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using ProjectDescent.WeaponSystem.Bullets;
    using UnityEngine;

    public class WeaponPhysicBullets : WeaponBase
    {
        [field: SerializeField, Header("Bullet")]
        public GameObject BulletPrefab { get; set; }
        [field: SerializeField]
        public float BulletSpeed { get; set; }

        override protected void OnBulletGeneration()
        {
            foreach (Transform barrel in BarrelsPoints)
            {
                if (Instantiate(BulletPrefab, barrel.transform.position, barrel.transform.rotation).TryGetComponent(out Bullet bull))
                {
                    bull.Init(CurrentDamage.Random(), BulletSpeed);
                }
            }
        }
    }
}