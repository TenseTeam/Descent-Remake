using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int PlayerShield = 100;
    public int MaxShield = 150;
    public int PlayerLives;
    public int PlayerEnergy = 100;
    public int MaxEnergy = 200;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sield Recharge"))
        {
            if (PlayerShield < MaxShield)
            {
                PlayerShield = MaxShield;

            }
        }
        if (collision.gameObject.CompareTag("Energy Recharge"))
        {
            if (PlayerEnergy < MaxShield)
            {
                PlayerEnergy = MaxEnergy;

            }
        }
    }
}
