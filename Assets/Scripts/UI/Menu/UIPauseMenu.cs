namespace ProjectDescent.UI
{
    using UnityEngine;
    using ProjectDescent.InputControllers;
    using UnityEngine.InputSystem;
    using System.Collections.Generic;

    /// <summary>
    /// This class is used for Pause the Game with a specified input
    /// activating or deactivating the pause UI gameobject
    /// and enable or disable the fullscreen
    /// </summary>
    [RequireComponent(typeof(PauseMenuInputsController))]
    public class UIPauseMenu : MonoBehaviour
    {
        [field: SerializeField, Header("UI")]
        public GameObject PanelPauseUI { get; set; }
        [field: SerializeField]
        public GameObject PauseMainUI { get; set; }

        [field: SerializeField]
        public List<InputsController> InputsControllerToDisable { get; set; }


        public bool IsPaused { get; private set; }


        private PauseMenuInputsController _inputs;

        private void Start()
        {
            _inputs = GetComponent<PauseMenuInputsController>();
            _inputs.OpenPauseMenuAction.performed += PauseIn;
        }

        private void PauseIn(InputAction.CallbackContext obj)
        {
            PauseToggle();
        }

        /// <summary>
        /// Pause the game by setting the time scale
        /// </summary>
        public void PauseToggle()
        {
            IsPaused = !IsPaused;

            if (IsPaused)
                SetTimeScale(0);
            else
                SetTimeScale(1);

            TogglePlayerInputs();
            PanelPauseUI.SetActive(IsPaused);

            if (IsPaused)
                ResetPauseMenu();
        }

        private void TogglePlayerInputs()
        {
            foreach (InputsController inp in InputsControllerToDisable)
            {
                if (IsPaused)
                    inp.Disable();
                else
                    inp.Enable();
            }
        }

        public void ResetPauseMenu()
        {
            for(int i = 0; i < PanelPauseUI.transform.childCount; i++)
            {
                PanelPauseUI.transform.GetChild(i).gameObject.SetActive(false);
            }

            PauseMainUI.SetActive(true);
        }

        public void SetTimeScale(int t)
        {
            Time.timeScale = t;
        }
    }
}