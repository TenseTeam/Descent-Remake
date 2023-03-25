namespace ProjectDescent.WeaponSystem.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using ProjectDescent.WeaponSystem.Bullets;
    using UnityEngine;

    public abstract class WeaponBase : MonoBehaviour
    {
        [field: SerializeField, Header("Damage")]
        public Range<float> BaseDamage { get; set; }

        [field: SerializeField]
        public float FireRate { get; set; } = 0.2f;

        [field: SerializeField, Header("Munitions")]
        public float MaxAmmunition { get; set; }

        [field: SerializeField]
        public float StartingAmmunition { get; set; }

        [field: SerializeField]
        public float AmmunitionCostPerShot { get; set; }

        [field: SerializeField, Header("Barrels")]
        public Transform[] BarrelsPoints { get; set; }

        public bool IsShooting { get; private set; }

        protected float CurrentAmmunition { get; set; }

        protected bool HasAmmo => CurrentAmmunition - AmmunitionCostPerShot >= 0f;

        protected Range<float> CurrentDamage { get; set; }

        private void Start()
        {
            SetupWeapon();
        }

        protected virtual void SetupWeapon()
        {
            CurrentDamage = BaseDamage;
            CurrentAmmunition = StartingAmmunition > MaxAmmunition ? MaxAmmunition : StartingAmmunition;
        }

        protected virtual void Shoot()
        {
            if (HasAmmo && !IsShooting)
            {
                StartCoroutine(ShootingRoutine());
            }
        }

        public virtual void AddAmmunition(uint ammoToAdd)
        {
            CurrentAmmunition += ammoToAdd;

            if (CurrentAmmunition > MaxAmmunition)
                CurrentAmmunition = MaxAmmunition;
        }

        protected abstract void OnBulletGeneration();

        private IEnumerator ShootingRoutine()
        {
            OnBulletGeneration();
            CurrentAmmunition -= AmmunitionCostPerShot;
            IsShooting = true;
            yield return new WaitForSeconds(FireRate);
            IsShooting = false;
        }

#if DEBUG || UNITY_EDITOR
        [ContextMenu("Debug Shoot")]
        private void DebugShoot()
        {
            Shoot();
        }
#endif
    }
}