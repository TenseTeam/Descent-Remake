namespace ProjectDescent.WeaponSystem.Bullets
{
    using UnityEngine;
    using Extension.SerializableClasses.Mathematics;

    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField, Header("Dispose")]
        public float TimeBeforeDestruction { get; set; }

        protected float Damage { get; set; } = 1f;
        protected float Speed { get; set; } = 1f;

        public void Init(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }

        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
            Destroy(gameObject, TimeBeforeDestruction);
#if DEBUG
            if (gameObject.layer == 0)
                Debug.LogWarning($"Bullet {transform.name} layer not setted. Remember to set the bullet layer in Project_Settings -> Physics -> Collision Matrix.");
#endif
        }

        private void Update()
        {
            MoveBullet();
        }

        protected virtual void MoveBullet()
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
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
