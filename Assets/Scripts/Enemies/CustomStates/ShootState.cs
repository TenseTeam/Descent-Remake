namespace ProjectDescent.AI.States
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ShootState : State
    {
        public Transform[] ShootPoints { get; private set; }
        public GameObject BulletPrefab { get; set; }
        public float FireRate { get; private set; }
        public Transform Self { get; private set; }
        public Transform Target { get; private set; }
        public float RotationSpeed { get; private set; }

        public ShootState(string name, Transform self, Transform target, Transform[] shootPoints, float fireRate, float rotationSpeed, GameObject bulletPrefab ) : base(name)
        {
            Self = self;
            Target = target;
            ShootPoints = shootPoints;
            FireRate = fireRate;
            BulletPrefab = bulletPrefab;
            RotationSpeed = rotationSpeed;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {  
        }

        public override void Process()
        {
            LookAtLerp();
        }


        private IEnumerator Shoot()
        {

            foreach (Transform point in ShootPoints) {
                UnityEngine.MonoBehaviour.Instantiate(BulletPrefab, point.position, point.rotation);

            }
            yield return new WaitForSeconds(FireRate);
        }

        private void LookAtLerp()
        {
            Vector3 relativePos = Target.position - Self.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            Self.rotation = Quaternion.Lerp(Self.rotation, toRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
