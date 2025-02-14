namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using ProjectDescent.UI.Interfaces;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class VulcanGun : WeaponRaycastBase, IWeaponUI
    {
        [field: SerializeField, Header("UI")]
        public string WeaponName { get; set; } = "Vulcan-Gun";

        [field: SerializeField]
        public TMP_Text WeaponNameText { get; set; }
        [field: SerializeField]
        public TMP_Text AmmoText { get; set; }
        [field: SerializeField]
        public Image WeaponImage { get; set; }
        [field: SerializeField]
        public Sprite WeaponIcon { get; set; }
        public bool IsSelected { get; set ; }

        public override void DeselectWeapon()
        {
            IsSelected = false;
            AmmoText.text = "";
        }

        public override void SelectWeapon()
        {
            IsSelected = true;
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
            if (IsSelected)
                AmmoText.text = Mathf.FloorToInt(CurrentAmmunition).ToString();
        }

        public void UpdateWeaponIcon()
        {
            WeaponImage.sprite = WeaponIcon;
        }

        public void UpdateWeaponName()
        {
            WeaponNameText.text = WeaponName;
        }

        public override void PullTrigger()
        {
            base.PullTrigger();
            UpdateAmmoText();
        }
    }
}