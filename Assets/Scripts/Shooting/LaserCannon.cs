using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannon : WeaponBase
{
    //====================================== Laser cannon stats
    [Header("Laser Cannons")]
    public GameObject[] LaserCannons;
    public GameObject LaserProjectile;
    public float LaserProjectileSpeed;
    public float LaserFireRate;
    public int LaserAmmos;
    private bool m_IsActive = true;

    // Update is called once per frame
    void Update()
    {
        //============================================ Shooting
        if (m_IsActive)
        {
            //mouse click
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                WeaponShoot();
            }
            //mouse hold
            if (Input.GetKey(KeyCode.Mouse0))
            {
                WeaponShoot();
            }
        }

        //====================================================== Active ordisactive the weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) m_IsActive = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) m_IsActive = false;
    }
    

    protected override void WeaponShoot()
    {
        int i = 0;
        GameObject p1 = Instantiate(LaserProjectile, LaserCannons[1].transform.position, LaserCannons[1].transform.rotation);
        p1.GetComponent<Rigidbody>().AddForce(Vector3.forward * LaserProjectileSpeed * Time.deltaTime);
        GameObject p2 = Instantiate(LaserProjectile, LaserCannons[2].transform.position, LaserCannons[2].transform.rotation);
        p2.GetComponent<Rigidbody>().AddForce(Vector3.forward * LaserProjectileSpeed * Time.deltaTime);
        i++;
        if (i >= 3)
        {
            --LaserAmmos;
            i = 0;
        }
        FireRate(LaserFireRate);
    }
}
