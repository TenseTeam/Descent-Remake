using System.Collections;
using UnityEngine;

public class VulcanGun : WeaponBase
{
    //====================================== Vulcan gun stats
    [Header("Vulcan Gun")]
    public GameObject VulcanCannon;

    public float FireRate;
    public int VulcanAmmo;
    public int AmmoRecharge;

    [Tooltip("time before the vulcan gun starts to shoot")]
    public float VulcanCharging;

    public float VulcanDamage;

    private bool m_IsHolding = false;

    // Update is called once per frame
    private void Update()
    {
        //============================================ Shooting
        if (m_IsActive)
        {
            //mouse hold
            if (Input.GetKey(KeyCode.Mouse0) && VulcanAmmo > 0 && !m_IsHolding)
            {
                StartCoroutine(Charging());
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                m_IsHolding = false;
                StopAllCoroutines();
            }
        }
    }

    protected override IEnumerator WeaponShoot()
    {
        Ray ray = new Ray(VulcanCannon.transform.position, VulcanCannon.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(VulcanDamage);
            }
        }
        --VulcanAmmo;
        yield return new WaitForSeconds(FireRate);
    }

    private IEnumerator Charging()
    {
        m_IsHolding = true;
        yield return new WaitForSeconds(VulcanCharging);
        StartCoroutine(WeaponShoot());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vulcan Ammo"))
        {
            VulcanAmmo += AmmoRecharge;
        }
    }
}