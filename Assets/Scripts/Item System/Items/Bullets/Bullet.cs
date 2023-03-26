namespace ProjectDescent.ItemSystem.Items.Bullets
{
    using UnityEngine;
    using Extension.SerializableClasses.Mathematics;

    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField, Header("Dispose")]
        public float TimeBeforeDestruction { get; set; }

        protected float Damage { get; set; } = 1f;
        protected float Speed { get; set; } = 1f;

        private Collider _coll;
        private Rigidbody _rb;

        public void Init(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }

        private void Start()
        {
            _coll = GetComponent<Collider>();
            _rb = GetComponent<Rigidbody>();

            _coll.isTrigger = true;
            Destroy(gameObject, TimeBeforeDestruction);
            MoveBullet();

#if DEBUG
            if (gameObject.layer == 0)
                Debug.LogWarning($"Bullet {transform.name} layer not setted. Remember to set the bullet layer in Project_Settings -> Physics -> Collision Matrix.");
#endif
        }

        protected virtual void MoveBullet()
        {
            _rb.velocity = transform.forward * Speed;
        }

        protected virtual void OnHit()
        {
            //ADD CONDITIONS FOR DOING DAMAGE
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other) // maybe can be private, lets see.
        {
            OnHit();
        }
    }
}
