namespace ProjectDescent.ItemSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    interface ILevelableWeapon : ILevelable
    {
        public float DamageIncreasePerLevel { get; set; }
    }
}
