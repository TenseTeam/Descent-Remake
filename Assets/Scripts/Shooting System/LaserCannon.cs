using System.Collections;
using UnityEngine;

public class LaserCannon : WeaponBase
{
    //====================================== Laser cannon stats
    [Header("Laser Cannons")]
    public Transform[] LaserCannons;
    public GameObject LaserProjectile;
    public float LaserFireRate;
    public int LaserAmmos;
    private PlayerStats LaserAmmo;

    //================================= Projectile stats
    [Header("Laser Projectile")]
    public float ProjectileDamage;
    public float ProjectileSpeed;

    private void Start()
    {
        LaserAmmo = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        //============================================ Shooting

        //mouse click
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(WeaponShoot());
        }
        //mouse hold
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(WeaponShoot());
        }


    }

    protected override IEnumerator WeaponShoot()
    {
        if (LaserAmmo.PlayerEnergy > 0)
        {
            foreach (Transform point in LaserCannons)
            {
                if (Instantiate(LaserProjectile, point.transform.position, point.transform.rotation).TryGetComponent(out Projectile prj))
                {
                    prj.SetUpProjectile(ProjectileDamage, ProjectileSpeed, 0.1f);
                }
            }
            int i = 0;
            i++;
            if (i >= 3)
            {
                --LaserAmmo.PlayerEnergy;
                i = 0;
            }
            yield return new WaitForSeconds(LaserFireRate);
        }
    }
}