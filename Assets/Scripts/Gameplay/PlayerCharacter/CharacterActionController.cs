namespace SotongStudio
{
    public interface ICharacterActionControl
    {
        void DoAttackProcess();
    }

    public class CharacterActionController : ICharacterActionControl
    {
        private IPlayerCharacter _playerCharacter;
        private IWeaponLogic _usedWeapon => _playerCharacter.UsedWeapon;

        public void DoAttackProcess()
        {
            _usedWeapon.DoAttackProcess();
        }
    }
}
