namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using ProjectDescent.ItemSystem.Items.Bullets;
    using UnityEngine;

    public class WeaponPhysicBase : WeaponBase
    {
        [field: SerializeField]
        public bool AlternateBarrel { get; private set; }

        [field: SerializeField, Header("Bullet")]
        public GameObject BulletPrefab { get; set; }
        [field: SerializeField]
        public float BulletSpeed { get; set; }

        private int _currentBarrelIndex = 0;

        protected override void BulletGeneration()
        {
            if (AlternateBarrel)
            {
                SpawnBullet(BarrelsPoints[_currentBarrelIndex]);
                _currentBarrelIndex = (_currentBarrelIndex + 1) % BarrelsPoints.Length;
            }
            else
            {
                foreach (Transform barrel in BarrelsPoints)
                {
                    SpawnBullet(barrel);
                }
            }
        }

        private void SpawnBullet(Transform barrel)
        {
            if (Instantiate(BulletPrefab, barrel.transform.position, barrel.transform.rotation).TryGetComponent(out Bullet bull))
            {
                bull.Init(Damage.Random(), BulletSpeed);
            }
        }
    }
}