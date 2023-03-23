using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionMissiles : SecondarySwitch
{
    //====================================== Concussion missles stats
    [Header("Concussion Missiles")]
    public GameObject ConcussionCannon;
    public GameObject ConcussionMissile;
    public float FireRate;
    public int ConcussionAmmo;
    public int AmmoRecharge;
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
        if (ConcussionAmmo > 0)
        {
                if (Instantiate(ConcussionMissile, ConcussionCannon.transform.position, ConcussionCannon.transform.rotation).TryGetComponent(out Projectile prj))
                {
                    prj.SetUpProjectile(MissileDamage, MissileSpeed, 0.5f);
                }
            int i = 0;
            i++;
            if (i >= 3)
            {
                --ConcussionAmmo;
                i = 0;
            }
            yield return new WaitForSeconds(FireRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Concussion Ammo"))
        {
            ConcussionAmmo += AmmoRecharge;
        }
    }
}


