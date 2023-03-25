using UnityEngine;

public class Harm : MonoBehaviour
{
    public float Damage;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out IDamageable damage))
        {
            damage.TakeDamage(Damage);
        }
    }
}