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

        private string GetWeaponStateName(int index) => Weapons[index].GetType().Name + " " + index.ToString();

        private void Awake()
        {
            _inputs = GetComponent<WeponInventoryInputsController>();
        }

        protected override void InitStates()
        {
            base.InitStates();

            for (int i = 0; i < Weapons.Count; i++)
            {
                States.Add(GetWeaponStateName(i), new WeaponState(GetWeaponStateName(i), Weapons[i], () => _inputs.IsShooting));
            }
        }

        protected override void Start()
        {
            base.Start();
            IndexWeapon = 0;
            ChangeState(GetWeaponStateName(IndexWeapon));
        }

        protected override void Update()
        {
            base.Update();

            if (_inputs.SwitchWeapon < 0 && IndexWeapon - 1 >= 0)
            {
                ChangeState(GetWeaponStateName(--IndexWeapon));
            }

            if (_inputs.SwitchWeapon > 0 && IndexWeapon + 1 < Weapons.Count)
            {
                ChangeState(GetWeaponStateName(++IndexWeapon));
            }
        }
    }
}
