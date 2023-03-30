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

        [field: SerializeField, Header("Path Raycast")]
        public float Range { get; private set; } = 100f;
        [field: SerializeField]
        public LayerMask PathLayerMask { get; private set; }

        private Transform _target;

        protected override void SetupBullet()
        {
            base.SetupBullet();

            
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
                if (gameObject.TryGetClosestGameObjectWithTag(LockOnTargetTag, out GameObject closest)
                && transform.IsPathClear(closest.transform, Range, PathLayerMask))
                {
                    Renderer rend = closest.GetComponentInChildren<Renderer>();

                    if (rend.isVisible)
                    {
                        _target = closest.transform;
                        transform.LookAtLerp(_target, RotationSpeed * Time.deltaTime);
                    }
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
