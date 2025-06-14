#nullable enable

using SotongStudio.VContainer;

namespace SotongStudio
{
    public interface ICharacterActionControl
    {
        void DoAttackProcess();
    }

    [RegisterAs(typeof(ICharacterActionControl))]
    public class CharacterActionController : ICharacterActionControl
    {
        private readonly IPlayerCharacter _playerCharacter;
        private int _currentChargeAmount;

        public CharacterActionController(IPlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        private IWeaponLogic _usedWeapon => _playerCharacter.UsedWeapon;

        public void DoAttackProcess()
        {
            if (_usedWeapon is IChargedWeapon chargedLogic)
            {
                WeaponChargeProcess(chargedLogic);
            }
            else
            {
                LaunchWeaponAttack();
            }
        }
        private void WeaponChargeProcess(IChargedWeapon chargedLogic)
        {
            var chargeNeed = chargedLogic.ChargeDuration;
            if (_currentChargeAmount >= chargeNeed)
            {
                LaunchWeaponAttack();
                _currentChargeAmount = 0; // Reset charge amount after attack
            }

            _currentChargeAmount++;

        }

        private void LaunchWeaponAttack()
        {
            _usedWeapon.DoAttackProcess();
        }


    }
}
