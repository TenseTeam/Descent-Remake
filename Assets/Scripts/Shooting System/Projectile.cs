using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Harm
{
    public float Speed { get; private set; }
    public float TimeBeforeDestroy { get; private set; }

    protected void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    public void SetUpProjectile(float damage, float speed, float time)
    {
        Damage = damage;
        this.Speed = speed;
        this.TimeBeforeDestroy = time;
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        Destroy(gameObject, TimeBeforeDestroy);
    }
}
