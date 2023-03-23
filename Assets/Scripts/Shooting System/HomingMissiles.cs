using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissiles : WeaponSwitch
{
    //====================================== Homing missles stats
    [Header("Homing Missiles")]
    public GameObject HomingCannon;
    public GameObject HomingMissile;
    public float FireRate;
    public int HomingAmmo;
    public int AmmoRecharge = 2;
    //================================= Projectile stats
    [Header("Missile")]
    public float MissileDamage;
    public float MissileSpeed;


    // Update is called once per frame
    void Update()
    {
        //===================================  Secondary weapon shoot
        if (m_ConcussionActive)
        {
            //mouse click
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine(WeaponShoot());
            }
            //mouse hold
            if (Input.GetKey(KeyCode.Mouse1))
            {
                StartCoroutine(WeaponShoot());
            }
        }
    }
    protected override IEnumerator WeaponShoot()
    {
        if (HomingAmmo > 0)
        {
            if (Instantiate(HomingMissile, HomingCannon.transform.position, HomingCannon.transform.rotation).TryGetComponent(out Projectile prj))
            {
                prj.SetUpProjectile(MissileDamage, MissileSpeed, 0.5f);
            }
            int i = 0;
            i++;
            if (i >= 3)
            {
                --HomingAmmo;
                i = 0;
            }
            yield return new WaitForSeconds(FireRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Homing Ammo"))
        {
            HomingAmmo += AmmoRecharge;
        }
    }
}
