namespace ProjectDescent.ItemSystem.Items.Weapons
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class LaserCannon : LevelableWeaponPhysic
    {
        [field: SerializeField]
        public TMP_Text LaserAmmo { get; private set; } 

        [field: SerializeField]
        public List<Image> LaserAmmoBars { get; set; }

        public override void Deselect()
        {
            base.Deselect();
            LevelText.text = "";
        }

        public override void AddAmmunition(float ammoToAdd)
        {
            base.AddAmmunition(ammoToAdd);
            UpdateAmmoText();
        }

        public override void UpdateAmmoText()
        {
            AmmoText.text = "";
            UpdateLaserAmmoText();
        }

        private void UpdateLaserAmmoText()
        {
            LaserAmmo.text = Mathf.FloorToInt(CurrentAmmunition).ToString();
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