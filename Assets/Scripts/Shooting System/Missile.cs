using UnityEngine;
public class Missile : Projectile
{
    public GameObject Explosion;

    protected override void OnTriggerEnter(Collider collision)
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        base.OnTriggerEnter(collision);
    }
}