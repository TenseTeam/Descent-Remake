using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : WeaponBase
{
    private SecondaryList m_SecondaryType;
    public bool m_ConcussionActive = true;
    private LaserCannon laserCannon;
    private VulcanGun vulcanGun;
    private bool vulcanActive = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SecondaryType = SecondaryList.Concussion;
        laserCannon = GetComponent<LaserCannon>();
        vulcanGun = GetComponent<VulcanGun>();
    }

    // Update is called once per frame
    void Update()
    {
        //====================================
        switch (m_SecondaryType)
        {
            case SecondaryList.Concussion:
                m_ConcussionActive = true;
                break;
            //=============================
            case SecondaryList.Homing:
                m_ConcussionActive = false;
                break;
        }
        //===================================
        if (!vulcanActive)
        {
            laserCannon.enabled = true;
            vulcanGun.enabled = false;
        }
        if (vulcanActive)
        {
            vulcanGun.enabled = true;
            laserCannon.enabled = false;
        }
        //====================================================== Change primary weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) vulcanActive = false;
        if (Input.GetKeyDown(KeyCode.Alpha2)) vulcanActive = true;
        //======================================================= Changing secondary weapon
        if (Input.GetKeyDown(KeyCode.Alpha3)) m_SecondaryType++;
        if (Input.GetKeyDown(KeyCode.Alpha4)) m_SecondaryType--;
    }
    protected override IEnumerator WeaponShoot()
    {
        throw new System.NotImplementedException();
    }
}

public enum SecondaryList
{
    Concussion,
    Homing,
}
