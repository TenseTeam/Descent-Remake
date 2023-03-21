using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionMissiles : SecondarySwitch
{
    //====================================== Concussion missles stats
    [Header("Concussion Missiles")]
    public GameObject ConcussionCannon;
    public GameObject ConcussionMissile;
    public float ConcussionMissilesSpeed;
    public float ConcussionMissilesFireRate;
    public int ConcussionAmmo;


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
        GameObject p1 = Instantiate(ConcussionMissile, ConcussionCannon.transform.position, ConcussionCannon.transform.rotation);
        p1.GetComponent<Rigidbody>().AddForce(Vector3.forward * ConcussionMissilesSpeed * Time.deltaTime);
        --ConcussionAmmo;
        FireRate(ConcussionMissilesFireRate);
    }
}


