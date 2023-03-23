using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySwitch : WeaponBase
{
    private SecondaryList m_SecondaryType;
    public bool m_ConcussionActive = true;

    // Start is called before the first frame update
    void Start()
    {
        m_SecondaryType = SecondaryList.Concussion;
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
        //===========================================================================  Changing weapon
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
