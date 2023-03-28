namespace Extension.TransformExtensions
{
    using UnityEngine;

    public static class TransformExtension
    {
        public static void LookAtLerp(this Transform self, Transform target, float t)
        {
            Vector3 relativePos = target.position - self.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            self.rotation = Quaternion.Lerp(self.rotation, toRotation, t);
        }

        public static bool IsPathClear(this Transform source, Transform target, float distance)
        {
            Vector3 direction = target.position - source.position;

            return (Physics.Raycast(source.position, direction, out RaycastHit hit, distance) && hit.transform == target);
        }
    }
}