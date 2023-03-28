namespace ProjectDescent.ItemSystem.Items.Bullets
{
    using UnityEngine;
    using ProjectDescent.EntitySystem.Interfaces;

    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField, Header("VFX")]
        public GameObject VFXOnHit { get; set; }

        [field: SerializeField, Header("Dispose")]
        public float TimeBeforeDestruction { get; set; }

        protected float Damage { get; set; } = 1f;
        protected float Speed { get; set; } = 1f;

        protected Rigidbody Rigidbody { get; set; }

        public virtual void Init(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            Rigidbody = GetComponent<Rigidbody>();

            Destroy(gameObject, TimeBeforeDestruction);
            SetupBullet();
#if DEBUG
            if (gameObject.layer == 0)
                Debug.LogWarning($"Bullet {transform.name} layer not setted. Remember to set the bullet layer in Project_Settings -> Physics -> Collision Matrix.");
#endif
        }

        protected virtual void SetupBullet()
        {
            MoveBullet();
        }

        protected virtual void MoveBullet()
        {
            Rigidbody.velocity = transform.forward * Speed;
        }

        protected virtual void OnHit(Transform hittedTransform)
        {
            if(hittedTransform.TryGetComponent(out IVulnerable ent))
            {
                ent.TakeDamage(Damage);
            }

            Instantiate(VFXOnHit, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other) // maybe can be private, lets see.
        {
            OnHit(other.transform);
        }
    }
}
