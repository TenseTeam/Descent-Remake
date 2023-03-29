namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using ProjectDescent.UI.Interfaces;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class HomingMissile : WeaponPhysicBase, IWeaponUI
    {
        [field: SerializeField, Header("UI")]
        public TMP_Text WeaponNameText { get ; set; }
        [field: SerializeField]
        public TMP_Text AmmoText { get; set; }
        [field: SerializeField]
        public Image WeaponImage { get; set; }
        [field: SerializeField]
        public Sprite WeaponIcon { get; set; }

        public override void Select()
        {
            base.Select();
            UpdateAllWeaponUI();
        }

        public void UpdateAllWeaponUI()
        {
            UpdateAmmoText();
            UpdateWeaponIcon();
            UpdateWeaponName();
        }

        public virtual void UpdateAmmoText()
        {
            AmmoText.text = Mathf.FloorToInt(CurrentAmmunition).ToString();
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