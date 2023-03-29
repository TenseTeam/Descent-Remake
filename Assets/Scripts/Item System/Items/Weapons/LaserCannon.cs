namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class LaserCannon : LevelableWeaponPhysic
    {
        [field: SerializeField]
        public List<Image> LaserAmmoBars { get; set; }


        public override void DeselectWeapon()
        {
            base.DeselectWeapon();
            LevelText.text = "";
        }

        public override void AddAmmunition(float ammoToAdd)
        {
            base.AddAmmunition(ammoToAdd);
            UpdateAmmoText();
        }

        public override void UpdateAmmoText()
        {
            AmmoText.text = Mathf.FloorToInt(CurrentAmmunition).ToString();
            UpdateLaserBarsUI();
        }

        private void UpdateLaserBarsUI()
        {
            foreach(Image bar in LaserAmmoBars)
            {
                bar.fillAmount = (CurrentAmmunition / maxAmmunition);
            }
        }
    }
}