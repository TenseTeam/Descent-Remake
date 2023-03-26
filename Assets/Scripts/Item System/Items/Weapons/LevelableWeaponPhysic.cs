namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using Extension.SerializableClasses.Mathematics;
    using ProjectDescent.ItemSystem.Interfaces;
    using UnityEngine;

    public class LevelableWeaponPhysic : WeaponPhysicBase, ILevelableWeapon
    {
        [field: SerializeField, Header("Levels")]
        public uint MaxLevel { get; set; } = 4;

        [field: SerializeField]
        public float DamageIncreasePerLevel { get; set; } = 1f;

        public uint CurrentLevel { get; set; } = 1;

        public void IncreaseLevel(uint levelsToAdd)
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


#if DEBUG || UNITY_EDITOR
        [ContextMenu("LevelUp")]
        private void LevelUp()
        {
            IncreaseLevel(1);
        }
#endif
    }
}