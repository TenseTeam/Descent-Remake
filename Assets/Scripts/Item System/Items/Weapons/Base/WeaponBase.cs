namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections;
    using Extension.SerializableClasses.Mathematics;
    using Extension.SerializableClasses.Audio;
    using Extension.Audio;
    using UnityEngine;

    public abstract class WeaponBase : MonoBehaviour
    {
        [field: SerializeField, Header("Damage")]
        public Range<float> Damage { get; set; }

        [field: SerializeField]
        public float FireRate { get; set; } = 0.2f;


        [field: SerializeField, Header("Munitions")]
        public bool HasInfiniteAmmo { get; set; } = false;

        public float maxAmmunition;

        public float startingAmmunition;

        [field: SerializeField]
        public float AmmunitionCostPerShot { get; set; }

        [field: SerializeField, Header("Audio")]
        public AudioSFX OnShootAudio { get; private set; }

        [field: SerializeField, Header("Barrels")]
        public Transform[] BarrelsPoints { get; set; }

        public bool IsShooting { get; private set; }

        protected float CurrentAmmunition { get; set; }

        protected bool HasAmmo => (CurrentAmmunition - AmmunitionCostPerShot >= 0f) || HasInfiniteAmmo;

        
        private void Awake()
        {
            SetupWeapon();
        }

        public virtual void SetupWeapon()
        {
            CurrentAmmunition = startingAmmunition;

            if (startingAmmunition > maxAmmunition)
            {
                startingAmmunition = maxAmmunition;
                CurrentAmmunition = startingAmmunition;
            }
        }

        public abstract void DeselectWeapon();
        public abstract void SelectWeapon();

        public virtual void PullTrigger()
        {
            if (HasAmmo && !IsShooting)
            {
                StartCoroutine(ShootingRoutine());
            }
        }

        public virtual void AddAmmunition(float ammoToAdd)
        {
            CurrentAmmunition += ammoToAdd;

            if (CurrentAmmunition > maxAmmunition)
                CurrentAmmunition = maxAmmunition;
        }

        protected virtual void BulletGeneration()
        {
            OnShootAudio.PlayClipAtPoint(transform.position);
        }



        private IEnumerator ShootingRoutine()
        {
            BulletGeneration();
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