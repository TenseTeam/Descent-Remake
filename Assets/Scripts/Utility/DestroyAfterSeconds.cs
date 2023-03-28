namespace ProjectDescent.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DestroyAfterSeconds : MonoBehaviour
    {
        [field: SerializeField, Header("Dispose")]
        public float TimeBeforeDestruction { get; set; }

        public virtual void Start()
        {
            Destroy(gameObject, TimeBeforeDestruction);
        }
    }
}
