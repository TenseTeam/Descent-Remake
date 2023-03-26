
namespace ProjectDescent.ItemSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    interface ILevelable
    {
        public uint MaxLevel { get; set; }
        public uint CurrentLevel { get; set; }
        public void IncreaseLevel(uint levelsToAdd);
    }
}
