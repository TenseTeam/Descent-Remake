using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcanGun : WeaponBase
{
    //====================================== Vulcan gun stats
    [Header("Vulcan Gun")]
    public GameObject VulcanCannon;
    public float VulcanFireRate;
    public int VulcanAmmo;
    public int VulcanAmmoRecharge;
    [Tooltip("time before the vulcan gun starts to shoot")]
    public float VulcanCharging;
    private bool m_IsActive = false;

    // Update is called once per frame
    void Update()
    {
        //============================================ Shooting
        if (m_IsActive)
        {
            //mouse hold
            if (Input.GetKey(KeyCode.Mouse0))
            {
                WeaponShoot();
            }
        }

        //====================================================== Active ordisactive the weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) m_IsActive = false;
        if (Input.GetKeyDown(KeyCode.Alpha2)) m_IsActive = true;
    }
    protected override void WeaponShoot()
    {
        Ray ray = new Ray(VulcanCannon.transform.position, VulcanCannon.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {

            }
        }
        --VulcanAmmo;
        FireRate(VulcanFireRate);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vulcan Ammo"))
        {
            VulcanAmmo += VulcanAmmoRecharge;
        }
    }

}
