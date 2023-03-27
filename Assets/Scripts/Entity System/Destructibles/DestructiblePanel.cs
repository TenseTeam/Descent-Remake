
namespace ProjectDescent.EntitySystem.Destructibles
{
    using UnityEngine;

    [RequireComponent(typeof(Renderer), typeof(AudioSource))]
    public class DestructiblePanel : DestructibleBase
    {
        [field: SerializeField, Header("Material")]
        public Material MaterialDestroyed { get; set; }

        private Renderer _render;
        private AudioSource _audio;

        private void Start()
        {
            _render = GetComponent<Renderer>();
            _audio = GetComponent<AudioSource>();
        }

        public override void Death()
        {
            _render.material = MaterialDestroyed;
            _audio.Play();
        }
    }
}
