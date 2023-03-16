using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Tooltip("Placeholder for the player energy that will be added later")]
    public int PlayerEnergy = 200;

    //Laser cannon stats
    [Header("Laser Cannons")]
    public GameObject[] LaserCannons;
    public GameObject LaserProjectile;
    public float LaserProjectileSpeed;
    public float LaserFireRate;

    //====================================== Vulcan gun stats
    [Header("Vulcan Gun")]
    public GameObject VulcanGun;
    public float VulcanFireRate;
    public int VulcanAmmo;
    [Tooltip("time before the vulcan gun starts to shoot")]
    public float VulcanCharging;

    //====================================== Concussion missles stats
    [Header("Concussion Missiles")]
    public GameObject ConcussionCannon;
    public GameObject ConcussionMissile;
    public float ConcussionMissilesSpeed;
    public float ConcussionMissilesFireRate;
    public int ConcussionAmmo;

    //====================================== Homing missles stats
    [Header("Homing Missiles")]
    public GameObject HomingCannon;
    public GameObject HomingMissiles;
    public float HomingMissilesSpeed;
    public float HomingMissilesFireRate;
    public int HomingAmmo;

    //====================================== Empty stats for the methods
    private GameObject m_Cannon;
    private GameObject m_Projectile;
    private float m_ProjectileSpeed;
    private float m_FireRate;
    private int m_Ammos;
    private bool m_VulcanActive = false;

    //====================================== used to switch between cannon types
    private SecondaryList m_SecondaryType;


    private void Start()
    {
        m_VulcanActive = false;
        m_SecondaryType = SecondaryList.Concussion;
    }


    // Update is called once per frame
    void Update()
    {
        //======================================
        switch (m_SecondaryType)
        {
            case SecondaryList.Concussion:
                m_Cannon = ConcussionCannon;
                m_Projectile = ConcussionMissile;
                m_ProjectileSpeed = ConcussionMissilesSpeed;
                m_FireRate = ConcussionMissilesFireRate;
                m_Ammos = ConcussionAmmo;
                break;
            //=================================
            case SecondaryList.Homing:
                m_Cannon = HomingCannon;
                m_Projectile = HomingMissiles;
                m_ProjectileSpeed = HomingMissilesSpeed;
                m_FireRate = HomingMissilesFireRate;
                m_Ammos = HomingAmmo;
                break;
        }
        //===========================================================================  Changing weapon
        if (Input.GetKeyDown(KeyCode.Alpha1)) m_VulcanActive = false;
        if (Input.GetKeyDown(KeyCode.Alpha2)) m_VulcanActive = true;
        if (Input.GetKeyDown(KeyCode.Alpha3)) m_SecondaryType++; 
        if (Input.GetKeyDown(KeyCode.Alpha4)) m_SecondaryType--; 

        //===========================================================================  Primary weapon shoot
        //mouse click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!m_VulcanActive) LaserShoot();
        }
        //mouse hold
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (m_VulcanActive) VulcanShoot();
            else if (!m_VulcanActive) LaserShoot();
        }
        //===================================  Secondary weapon shoot
        //mouse click
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SecondaryWeaponShoot(m_Cannon, m_Projectile, m_ProjectileSpeed, m_FireRate, m_Ammos);
        }
        //mouse hold
        if (Input.GetKey(KeyCode.Mouse1))
        {
            SecondaryWeaponShoot(m_Cannon, m_Projectile, m_ProjectileSpeed, m_FireRate, m_Ammos);
        }
    }

    /// <summary>
    /// Secondary weapon shooting system
    /// (Instantiate and AddForce of the projectile)
    /// </summary>
    /// <param name="launchingPoint1">First cannon</param>
    /// <param name="launchingPoint2">Second cannon if it exist</param>
    /// <param name="projectile">projectile</param>
    /// <param name="projectileSpeed">speed of the projectile</param>
    /// <param name="fireRate">projectile shooting deelay</param>
    /// <param name="ammocount">current weapon's ammo amount</param>
    private void SecondaryWeaponShoot(GameObject launchingPoint, GameObject projectile, float projectileSpeed, float fireRate, int ammocount)
    {
        GameObject p1 = Instantiate(projectile, launchingPoint.transform.position, launchingPoint.transform.rotation);
        p1.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileSpeed * Time.deltaTime);
        --ammocount;
        WeaponFireRate(fireRate);
    }

    /// <summary>
    /// Laser only shooting system (Double projectile instance in 2 different positions)
    /// </summary>
    private void LaserShoot()
    {
        int i = 0;
        GameObject p1 = Instantiate(LaserProjectile, LaserCannons[1].transform.position, LaserCannons[1].transform.rotation);
        p1.GetComponent<Rigidbody>().AddForce(Vector3.forward * LaserProjectileSpeed * Time.deltaTime);
        GameObject p2 = Instantiate(LaserProjectile, LaserCannons[2].transform.position, LaserCannons[2].transform.rotation);
        p2.GetComponent<Rigidbody>().AddForce(Vector3.forward * LaserProjectileSpeed * Time.deltaTime);
        i++;
        if (i >= 3)
        {
            --PlayerEnergy;
            i = 0;
        }
        WeaponFireRate(LaserFireRate);
    }

    /// <summary>
    /// Vulcan only shooting system (Raycast mechanic)
    /// </summary>
    private void VulcanShoot()
    {
        Ray ray = new Ray(VulcanGun.transform.position, VulcanGun.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                
            }
        }
        --VulcanAmmo;
        WeaponFireRate(VulcanFireRate);
    }

    private IEnumerator WeaponFireRate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

//=============================================

public enum SecondaryList
{
    Concussion,
    Homing,
}

