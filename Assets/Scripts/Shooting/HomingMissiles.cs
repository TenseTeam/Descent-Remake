using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissiles : SecondarySwitch
{
    //====================================== Homing missles stats
    [Header("Homing Missiles")]
    public GameObject HomingCannon;
    public GameObject HomingMissile;
    public float HomingMissilesSpeed;
    public float HomingMissilesFireRate;
    public int HomingAmmo;
    public int HomingAmmoRecharge = 2;


    // Update is called once per frame
    void Update()
    {
        //===================================  Secondary weapon shoot
        if (m_ConcussionActive)
        {
            //mouse click
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                WeaponShoot();
            }
            //mouse hold
            if (Input.GetKey(KeyCode.Mouse1))
            {
                WeaponShoot();
            }
        }
    }
    protected override void WeaponShoot()
    {
        GameObject p1 = Instantiate(HomingMissile, HomingCannon.transform.position, HomingCannon.transform.rotation);
        p1.GetComponent<Rigidbody>().AddForce(Vector3.forward * HomingMissilesSpeed * Time.deltaTime);
        --HomingAmmo;
        FireRate(HomingMissilesFireRate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Homing Ammo"))
        {
            HomingAmmo += HomingAmmoRecharge;
        }
    }
}
