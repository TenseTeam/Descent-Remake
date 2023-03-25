namespace ProjectDescent.WeaponSystem.Weapons
{
    using UnityEngine;
    using Extension.SerializableClasses.Mathematics;

    public class PlayerWeaponBase : WeaponPhysicBullets
    {
        [field: SerializeField]
        public float DamageIncreasePerLevel { get; set; } = 5f;
        [field: SerializeField]
        public uint WeaponLevel { get; set; } = 1;

        protected uint CurrentWeaponLevel { get; set; } = 1;

        override protected void SetupWeapon()
        {
            base.SetupWeapon();
            CurrentWeaponLevel = WeaponLevel;
            CurrentDamage = new Range<float>(BaseDamage.Min + ((DamageIncreasePerLevel - 1) * CurrentWeaponLevel), BaseDamage.Max + ((DamageIncreasePerLevel - 1) * CurrentWeaponLevel));
        }
    }
}
