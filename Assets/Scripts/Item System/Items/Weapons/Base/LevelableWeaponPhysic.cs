﻿namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using ProjectDescent.UI.Interfaces;
    using ProjectDescent.ItemSystem.Interfaces;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;

    public class LevelableWeaponPhysic : WeaponPhysicBase, ILevelableWeapon, IWeaponUI
    {
        [field: SerializeField, Header("Levels")]
        public uint MaxLevel { get; set; } = 4;

        [field: SerializeField]
        public float DamageIncreasePerLevel { get; set; } = 1f;
        public uint CurrentLevel { get; set; } = 1;

        #region UI

        [field: SerializeField, Header("UI")]
        public TMP_Text WeaponNameText { get; set; }
        [field: SerializeField]
        public TMP_Text AmmoText { get ; set; }
        [field: SerializeField]
        public TMP_Text LevelText { get; set; }

        [field: SerializeField]
        public Image WeaponImage { get; set; }
        [field: SerializeField]
        public Sprite WeaponIcon { get; set; }
        #endregion

        public void IncreaseLevel(uint levelsToAdd = 1)
        {
            CurrentLevel += levelsToAdd;
            if (CurrentLevel > MaxLevel)
            {
                CurrentLevel = MaxLevel;
                return;
            }

            Damage.Min += DamageIncreasePerLevel * levelsToAdd;
            Damage.Max += DamageIncreasePerLevel * levelsToAdd;

            UpdateLevelText();
        }

        public override void Select()
        {
            UpdateAllWeaponUI();
        }

        protected override void BulletGeneration()
        {
            base.BulletGeneration();
            UpdateAmmoText();
        }

        public void UpdateAllWeaponUI()
        {
            UpdateAmmoText();
            UpdateLevelText();
            UpdateWeaponIcon();
            UpdateWeaponName();
        }

        public void UpdateAmmoText()
        {
            AmmoText.text = CurrentAmmunition.ToString();
        }

        public void UpdateLevelText()
        {
            LevelText.text = CurrentLevel.ToString();
        }

        public void UpdateWeaponIcon()
        {
            WeaponImage.sprite = WeaponIcon;
        }

        public void UpdateWeaponName()
        {
            WeaponNameText.text = GetType().Name;
        }
    }
}