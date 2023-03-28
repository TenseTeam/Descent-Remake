
namespace ProjectDescent.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ActivateGameObjectOnTrigger : MonoBehaviour
    {
        public string triggerTag = "Player";
        public GameObject gameObjectToEnable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(triggerTag))
                gameObjectToEnable.SetActive(true);
        }
    }
}