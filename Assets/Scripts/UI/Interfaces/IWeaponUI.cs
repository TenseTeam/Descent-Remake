namespace ProjectDescent.UI.Interfaces
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    interface IWeaponUI
    {
        public string WeaponName { get; set; }
        public TMP_Text WeaponNameText { get; set; }
        public TMP_Text AmmoText { get; set; }
        public Image WeaponImage { get; set; }
        public Sprite WeaponIcon { get; set; }

        public bool IsSelected { get; set; }

        void UpdateWeaponName();
        void UpdateAmmoText();
        void UpdateWeaponIcon();
        void UpdateAllWeaponUI();
    }
}