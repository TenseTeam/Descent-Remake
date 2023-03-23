using UnityEngine;

public class Explosion : Harm
{
    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        Destroy(gameObject);
    }
}