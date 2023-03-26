namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using ProjectDescent.ItemSystem.Interfaces;
    using UnityEngine;

    public class LevelableWeaponRaycast : WeaponRaycastBase, ILevelableWeapon
    {
        [field: SerializeField, Header("Levels")]
        public uint MaxLevel { get; set; }

        [field: SerializeField]
        public float DamageIncreasePerLevel { get; set; }

        public uint CurrentLevel { get; set; } = 1;

        public void IncreaseLevel(uint levelsToAdd = 1)
        {
            CurrentLevel += levelsToAdd;
            if (CurrentLevel > MaxLevel)
            {
                CurrentLevel = MaxLevel;
                return;
            }

            Damage.Min += DamageIncreasePerLevel;
            Damage.Max += DamageIncreasePerLevel;
        }
    }
}