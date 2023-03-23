using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ExplosionRange;
    public int Damage;
    [Tooltip("Damage reduction on player when the projectile hits it")]
    public int DamageReduction;
    private Player player;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
            GetComponent<SphereCollider>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.HP -= Damage / DamageReduction;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
