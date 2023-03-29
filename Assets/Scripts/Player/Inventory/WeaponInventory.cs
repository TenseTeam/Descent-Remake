namespace ProjectDescent.Player.Inventory
{
    using System.Collections.Generic;
    using ProjectDescent.InputControllers;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using Extension.StateMachine;
    using UnityEngine;

    [RequireComponent(typeof(WeponInventoryInputsController))]
    public class WeaponInventory : StateMachine
    {
        [field: SerializeField]
        public List<WeaponBase> Weapons { get; set; }

        private int IndexWeapon { get; set; }
        private WeponInventoryInputsController _inputs;

        private string GetWeaponStateKey(int index) => Weapons[index].GetInstanceID().ToString();

        protected override void Awake()
        {
            base.Awake();
            _inputs = GetComponent<WeponInventoryInputsController>();
        }

        protected override void InitStates()
        {
            base.InitStates();

            foreach (WeaponBase weap in Weapons)
            {
                States.Add(weap.GetInstanceID().ToString(), new WeaponState(weap.GetInstanceID().ToString(), weap, () => _inputs.IsShooting));
            }

            IndexWeapon = 0;
            ChangeState(GetWeaponStateKey(IndexWeapon));
        }

        protected override void Update()
        {
            base.Update();

            if (_inputs.SwitchWeapon < 0 && IndexWeapon - 1 >= 0 && Weapons[IndexWeapon-1].enabled)
            {
                ChangeState(GetWeaponStateKey(--IndexWeapon));
            }

            if (_inputs.SwitchWeapon > 0 && IndexWeapon + 1 < Weapons.Count && Weapons[IndexWeapon + 1].enabled)
            {
                ChangeState(GetWeaponStateKey(++IndexWeapon));
            }
        }
    }
}
