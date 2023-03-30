
namespace ProjectDescent.Player.Entity
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using TMPro;
    using ProjectDescent.EntitySystem;

    public class PlayerEntityDamageOverTimeOnTrigger : MonoBehaviour
    {
        [field: SerializeField, Header("Damage")]
        public float DamagePerSecond { get; private set; }

        public void OnTriggerStay(Collider other)
        {
            if(other.TryGetComponent(out PlayerEntity player))
            {
                player.TakeDamage(DamagePerSecond * Time.deltaTime);
            }
        }
    }
}
