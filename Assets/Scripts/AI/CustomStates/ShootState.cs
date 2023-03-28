namespace ProjectDescent.AI.States
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.StateMachine;
    using Extension.TransformExtensions;
    using ProjectDescent.ItemSystem.Items.Weapons;

    public class ShootState : State
    {
        public WeaponBase Weapon { get; set; }
        
        private Transform _self;
        private Transform _target;
        private float _rotationSpeed;

        public ShootState(string name, Transform self, Transform target, WeaponBase weaponUsed, float rotationSpeed) : base(name)
        {
            _self = self;
            _target = target;
            Weapon = weaponUsed;
            _rotationSpeed = rotationSpeed;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {  
        }

        public override void Process()
        {
            _self.LookAtLerp(_target, _rotationSpeed * Time.deltaTime);
            Weapon.PullTrigger();
        }
    }
}
