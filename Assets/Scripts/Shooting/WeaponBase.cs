using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected abstract void WeaponShoot();
    protected IEnumerator FireRate(float fireRate)
    {
        yield return new WaitForSeconds(fireRate);
    }
    protected void AmmoReload(int ammosPickUp, int totalAmmos)
    {
        totalAmmos += ammosPickUp;
    }
}
