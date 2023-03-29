namespace ProjectDescent.AI.Behaviours
{
    using System.Collections.Generic;
    using ProjectDescent.EntitySystem;
    using UnityEngine;

    public class EnemyEntity : EntityBase
    {
        [field: SerializeField, Header("Items Drop")]
        public List<GameObject> PossibleItemsDrop { get; private set; }
        [field: SerializeField, Range(0, 100)]
        public float DropRate { get; set; }

        [field: SerializeField, Header("VFXOnDeath")]
        public GameObject VFXExplosion { get; private set; }

        [field: SerializeField]
        public int ScoreToAddOnKill { get; private set; }

        public override void Death()
        {
            Instantiate(VFXExplosion, transform.position, transform.rotation);
            ScoreSingleton.instance.AddScore(ScoreToAddOnKill);

            if(Random.Range(0, 100) < DropRate)
            {
                Instantiate(PossibleItemsDrop[Random.Range(0, PossibleItemsDrop.Count)], transform.position, transform.rotation);
            }

            base.Death();
        }
    }
}