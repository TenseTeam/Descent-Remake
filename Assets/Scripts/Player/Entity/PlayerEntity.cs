
namespace ProjectDescent.Player.Entity
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using ProjectDescent.EntitySystem;

    public class PlayerEntity : EntityBase
    {
        public float maxShieldHitPoints = 200f;
        public float ShieldHitPoints { get; private set; }

        [field: SerializeField, Header("UI")]
        public TMP_Text HPText { get; private set; }
        [field: SerializeField]
        public TMP_Text ShieldText { get; private set; }

        [field: SerializeField]
        public Image HPImage { get; private set; }

        [field: SerializeField]
        public List<Sprite> ShieldPhaseSprites { get; set; }
        //private Queue<Material> _queueSprites;


        protected override void SetupHP()
        {
            base.SetupHP();
            ShieldHitPoints = maxShieldHitPoints;
            UpdateUI();
        }

        public override void TakeDamage(float hitDamage = 1f)
        {
            hitDamage = Mathf.Abs(hitDamage);

            if (ShieldHitPoints > 0f)
            {
                if (ShieldHitPoints >= hitDamage)
                {
                    ShieldHitPoints -= hitDamage;
                    UpdateUI();
                    return;
                }
                else
                {
                    hitDamage -= ShieldHitPoints;
                    ShieldHitPoints = 0f;
                }
            }

            HitPoints -= hitDamage;
            if (HitPoints <= 0)
            {
                HitPoints = 0;
                Death();
            }

            UpdateUI();
        }


        public override void HealHitPoints(float healPoints)
        {
            float remainingHealPoints = Mathf.Abs(healPoints);
            if (HitPoints < maxHitPoints)
            {
                float missingHitPoints = maxHitPoints - HitPoints;
                if (missingHitPoints >= remainingHealPoints)
                {
                    HitPoints += remainingHealPoints;
                    UpdateUI();
                    return;
                }
                else
                {
                    HitPoints += missingHitPoints;
                    remainingHealPoints -= missingHitPoints;
                }
            }

            if (ShieldHitPoints < maxShieldHitPoints)
            {
                float missingShieldHitPoints = maxShieldHitPoints - ShieldHitPoints;
                if (missingShieldHitPoints >= remainingHealPoints)
                {
                    ShieldHitPoints += remainingHealPoints;
                }
                else
                {
                    ShieldHitPoints += missingShieldHitPoints;
                }
            }

            UpdateUI();
        }


        public override void Death()
        {
            Debug.Log("DEATH");
        }

        private void UpdateUI()
        {
            HPText.text = Mathf.FloorToInt(HitPoints).ToString();
            ShieldText.text = Mathf.FloorToInt(ShieldHitPoints).ToString();
            UpdateShieldIcon();
        }

        private void UpdateShieldIcon()
        {
            if (ShieldPhaseSprites == null || ShieldPhaseSprites.Count == 0)
            {
                Debug.LogWarning("No Shield phase sprites set for PlayerEntity");
                return;
            }

            float shieldPercent = ShieldHitPoints / maxShieldHitPoints;
            int phaseIndex = Mathf.FloorToInt(shieldPercent * (ShieldPhaseSprites.Count - 1));
            HPImage.sprite = ShieldPhaseSprites[phaseIndex];
        }
    }
}
