namespace ProjectDescent.Player.Entity
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class PlayerEntityHealOnTrigger : MonoBehaviour
    {
        [field: SerializeField]
        public float HitPointsHealQuantity { get; private set; }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerEntity playerEnt))
            {
                playerEnt.HealHitPoints(HitPointsHealQuantity);
                Destroy(gameObject);
            }
        }
    }
}