namespace ProjectDescent.Player.Inventory
{
    using System.Linq;
    using Extension.StateMachine;
    using ProjectDescent.ItemSystem.Items.Weapons;
    using ProjectDescent.UI.Interfaces;

    public class WeaponState : State
    {
        public delegate bool InputCheckDelegate();

        public WeaponBase Gun { get; private set; } // Maybe changing WeaponBase to the leveled one that has UpdateUI !
        public InputCheckDelegate InputCheck { get; private set; }

        public WeaponState(string name, WeaponBase gun, InputCheckDelegate inputCheck) : base(name)
        {
            Gun = gun;
            InputCheck = inputCheck;
        }

        public override void Enter()
        {
            Gun.SelectWeapon();
        }

        public override void Exit()
        {
            Gun.DeselectWeapon();
        }

        public override void Process()
        {
            if (InputCheck())
            {
                Gun.PullTrigger();
            }
        }
    }
}