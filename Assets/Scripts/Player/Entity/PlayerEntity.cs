
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
        [field: SerializeField, Header("Spawn")]
        public Transform SpawnPoint { get; private set; }

        [field: SerializeField]
        public int SceneBuildIndexToLoadOnDefiniteDeath { get; set; } = 0;

        [field: SerializeField, Header("UI")]
        public TMP_Text HPText { get; private set; }

        [field: SerializeField]
        public TMP_Text RemainingLivesText { get; private set; }

        [field: SerializeField]
        public Image HPImage { get; private set; }

        [field: SerializeField]
        public List<Sprite> ShieldPhaseSprites { get; set; }

        [Header("Lives")]
        public static int maxLives = 3;
        [Range(0, 3)]public int startingMaxLives = 3;
        private int _currentLives;

        protected override void SetupHP()
        {
            base.SetupHP();

            _currentLives = startingMaxLives;
            if (startingMaxLives > maxLives) // just for the future, it is not needed due to the Range
                _currentLives = maxLives;

            UpdateRemainingLivesUI();
            UpdateHitPointsUI();
        }

        public override void TakeDamage(float hitDamage = 1f)
        {
            hitDamage = Mathf.Abs(hitDamage);

            hitPoints -= hitDamage;
            if (hitPoints <= 0)
            {
                hitPoints = 0;
                Death();
            }

            UpdateHitPointsUI();
        }


        public override void HealHitPoints(float healPoints)
        {
            healPoints = Mathf.Abs(healPoints);

            hitPoints += healPoints;
            if (hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }

            UpdateHitPointsUI();
        }


        public override void Death()
        {
            _currentLives--;
            ScoreSingleton.instance.ResetScore();

            if (_currentLives > -1)
            {
                transform.position = SpawnPoint.position;
                hitPoints = startingHitPoints;
                UpdateRemainingLivesUI();
                return;
            }

            _currentLives = maxLives;
            SceneManager.LoadScene(SceneBuildIndexToLoadOnDefiniteDeath, LoadSceneMode.Single);
        }

        private void UpdateHitPointsUI()
        {
            HPText.text = Mathf.FloorToInt(hitPoints).ToString();
            UpdateShieldIconUI();
        }

        private void UpdateShieldIconUI()
        {
            if (ShieldPhaseSprites == null || ShieldPhaseSprites.Count == 0)
            {
                Debug.LogWarning("No Shield phase sprites set for PlayerEntity");
                return;
            }

            float shieldPercent = hitPoints / maxHitPoints;
            int phaseIndex = Mathf.FloorToInt(shieldPercent * (ShieldPhaseSprites.Count - 1));
            HPImage.sprite = ShieldPhaseSprites[phaseIndex];
        }

        private void UpdateRemainingLivesUI()
        {
            RemainingLivesText.text = " x " + _currentLives.ToString();
        }
    }
}
