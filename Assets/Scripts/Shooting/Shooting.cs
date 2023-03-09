using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 500f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject ball = Instantiate(projectile, transform.position,transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * launchVelocity * Time.deltaTime);
    }
}

