namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using ProjectDescent.UI.Interfaces;
    using ProjectDescent.ItemSystem.Interfaces;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using System;

    public class LevelableWeaponRaycast : WeaponRaycastBase, ILevelableWeapon, IWeaponUI
    {
        [field: SerializeField, Header("Levels")]
        public uint MaxLevel { get; set; }

        [field: SerializeField]
        public float DamageIncreasePerLevel { get; set; }

        public uint CurrentLevel { get; set; } = 1;

        #region UI

        [field: SerializeField, Header("UI")]
        public string WeaponName { get; set; } = "Weapon";

        [field: SerializeField]
        public TMP_Text WeaponNameText { get; set; }
        [field: SerializeField]
        public TMP_Text AmmoText { get; set; }
        [field: SerializeField]
        public TMP_Text LevelText { get; set; }

        [field: SerializeField]
        public Image WeaponImage { get; set; }
        [field: SerializeField]
        public Sprite WeaponIcon { get; set; }

        public bool IsSelected { get; set; }
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

            if (IsSelected)
                UpdateLevelText();
        }

        public override void AddAmmunition(float ammoToAdd)
        {
            base.AddAmmunition(ammoToAdd);

            if (IsSelected)
                UpdateAmmoText();
        }

        public override void DeselectWeapon()
        {
            IsSelected = false;
        }

        public override void SelectWeapon()
        {
            IsSelected = true;
            UpdateAllWeaponUI();
        }

        public override void PullTrigger()
        {
            base.PullTrigger();
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

            AmmoText.text = Math.Round(CurrentAmmunition, 1).ToString();
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