using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int PlayerShield = 100;
    public int ShieldRecharge = 50;
    [Tooltip("Max shield reachable")]
    public int MaxShield = 150;
    //==========================
    public int PlayerLives;
    //==========================
    public int PlayerEnergy = 100;
    public int EnergyRecharge = 100;
    [Tooltip("Max energy reachable")]
    public int MaxEnergy = 200;

    //========================================================= Recharge system pickup

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sield Recharge"))
        {
            RechargeStat(PlayerShield, ShieldRecharge, MaxShield);
        }
        if (other.gameObject.CompareTag("Energy Recharge"))
        {
            RechargeStat(PlayerEnergy, EnergyRecharge, MaxEnergy);
        }
    }
    private void RechargeStat(int baseStat, int rechargeValue, int maxStat)
    {
        baseStat += rechargeValue;
        if (baseStat > maxStat)
        {
            baseStat = maxStat;
        }
    }
}

