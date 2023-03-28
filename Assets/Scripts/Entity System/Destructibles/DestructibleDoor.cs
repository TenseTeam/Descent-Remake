
namespace ProjectDescent.EntitySystem.Destructibles
{
    using UnityEngine;
    using System.Collections.Generic;

    [RequireComponent(typeof(Renderer), typeof(Collider))]
    public class DestructibleDoor : DestructiblePhasesBase
    {
        [field: SerializeField, Header("Materials")]
        public List<Material> DestroyedPhaseMaterials { get; set; }

        private Renderer _render;
        private Collider _coll;
        private Queue<Material> _queueMaterials;

        protected override void Setup()
        {
            base.Setup();
            _render = GetComponent<Renderer>();
            _coll = GetComponent<Collider>();
            _queueMaterials = new Queue<Material>(DestroyedPhaseMaterials);
        }

        public override void NextPhase()
        {
            base.NextPhase();
            if(_queueMaterials.TryDequeue(out Material mat))
            {
                _render.material = mat;
            }
        }

        public override void Death()
        {
            HitPoints = 0;
            _coll.enabled = false;
        }
    }
}
