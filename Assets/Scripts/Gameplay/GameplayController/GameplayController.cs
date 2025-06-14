using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{
    public class GameplayController : IStartable
    {
        private readonly IWeaponSwitchLogic _weaponSwitch;

        public GameplayController(IWeaponSwitchLogic weaponSwitch,
                                  ITurnControl turnControl,
                                  ICharacterActionControl characterActionControl)
        {
            turnControl.OnTurnChange.AddListener(characterActionControl.DoAttackProcess);
            _weaponSwitch = weaponSwitch;
        }

        public void Start()
        {
            _weaponSwitch.SwitchPlayerWeapon(PlayerWeapon.Sword);
        }
    }
}
