using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int PlayerShield = 100;
    [Tooltip("Max shield reachable")]
    public int MaxShield = 150;
    public int PlayerLives;
    public int PlayerEnergy = 100;
    [Tooltip("Max energy reachable")]
    public int MaxEnergy = 200;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sield Recharge"))
        {
            if (PlayerShield < MaxShield)
            {
                PlayerShield = MaxShield;

            }
        }
        if (other.gameObject.CompareTag("Energy Recharge"))
        {
            if (PlayerEnergy < MaxShield)
            {
                PlayerEnergy = MaxEnergy;

            }
        }
    }
}
