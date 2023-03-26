namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using UnityEngine;

    public abstract class WeaponBase : MonoBehaviour
    {
        [field: SerializeField, Header("Damage")]
        public Range<float> Damage { get; set; }

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

        private void Start()
        {
            SetupWeapon();
        }

        protected virtual void SetupWeapon()
        {
            CurrentAmmunition = StartingAmmunition > MaxAmmunition ? MaxAmmunition : StartingAmmunition;
        }

        protected virtual void PullTrigger()
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

        protected abstract void OnShoot();

        private IEnumerator ShootingRoutine()
        {
            OnShoot();
            CurrentAmmunition -= AmmunitionCostPerShot;
            IsShooting = true;
            yield return new WaitForSeconds(FireRate);
            IsShooting = false;
        }

#if DEBUG || UNITY_EDITOR
        [ContextMenu("Debug Shoot")]
        private void DebugShoot()
        {
            PullTrigger();
        }
#endif
    }
}