
namespace ProjectDescent.Player.Entity
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using TMPro;
    using ProjectDescent.EntitySystem;

    public class PlayerEntity : EntityBase
    {
        public float maxShieldHitPoints = 200f;
        public float ShieldHitPoints { get; private set; }

        [field: SerializeField]
        public int SceneBuildIndexToLoadOnDefiniteDeath { get; set; } = 0;

        [field: SerializeField, Header("UI")]
        public TMP_Text HPText { get; private set; }
        [field: SerializeField]
        public TMP_Text ShieldText { get; private set; }
        [field: SerializeField]
        public TMP_Text RemainingLivesText { get; private set; }

        [field: SerializeField]
        public Image HPImage { get; private set; }

        [field: SerializeField]
        public List<Sprite> ShieldPhaseSprites { get; set; }


        private static uint _currentLives = 3;

        protected override void SetupHP()
        {
            base.SetupHP();
            ShieldHitPoints = maxShieldHitPoints;
            UpdateRemainingLivesUI();
            UpdateHitPointsUI();
        }

        public override void TakeDamage(float hitDamage = 1f)
        {
            hitDamage = Mathf.Abs(hitDamage);

            if (ShieldHitPoints > 0f)
            {
                if (ShieldHitPoints >= hitDamage)
                {
                    ShieldHitPoints -= hitDamage;
                    UpdateHitPointsUI();
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

            UpdateHitPointsUI();
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
                    UpdateHitPointsUI();
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

            UpdateHitPointsUI();
        }


        public override void Death()
        {
            _currentLives--;

            if (_currentLives >= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                return;
            }

            _currentLives = 3;
            SceneManager.LoadScene(SceneBuildIndexToLoadOnDefiniteDeath, LoadSceneMode.Single);
        }

        private void UpdateHitPointsUI()
        {
            HPText.text = Mathf.FloorToInt(HitPoints).ToString();
            ShieldText.text = Mathf.FloorToInt(ShieldHitPoints).ToString();
            UpdateShieldIconUI();
        }

        private void UpdateShieldIconUI()
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

        private void UpdateRemainingLivesUI()
        {
            RemainingLivesText.text = " x " + _currentLives.ToString();
        }
    }
}
