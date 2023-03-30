namespace ProjectDescent.ItemSystem.Items.Bullets
{
    using UnityEngine;
    using Extension.Finders;
    using Extension.TransformExtensions;
    using ProjectDescent.EntitySystem.Interfaces;
    using System.Collections;

    public class HomingMissile : Missile
    {
        [field: SerializeField]
        public string LockOnTargetTag { get; set; } = "Enemy";

        [field: SerializeField]
        public float RotationSpeed { get; set; } = 2f;

        private Transform _target;

        protected override void SetupBullet()
        {
            base.SetupBullet();

            if(gameObject.TryGetClosestGameObjectWithTag(LockOnTargetTag, out GameObject closest))
            {
                Renderer rend = closest.GetComponentInChildren<Renderer>();

                Debug.Log(rend.transform.name);
                if (rend.isVisible)
                {
                    _target = closest.transform;
                    StartCoroutine(LockOnRoutine());
                }
            }
        }

        private void Update()
        {
            MoveBullet();
        }

        protected override void MoveBullet()
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        protected override void OnHit(Transform hittedTransform)
        {
            StopCoroutine(LockOnRoutine());
            base.OnHit(hittedTransform);
        }

        private IEnumerator LockOnRoutine()
        {
            while (true)
            {
                try
                {
                    transform.LookAtLerp(_target, RotationSpeed * Time.deltaTime);
                }
                catch
                {
                    // Catch the exception in case _target has been destroyed
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
