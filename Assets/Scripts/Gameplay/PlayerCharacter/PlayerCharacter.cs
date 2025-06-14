using SotongStudio.VContainer;

namespace SotongStudio
{
    public interface IPlayerCharacter
    {
        IWeaponLogic UsedWeapon { get; }
        void SetEquipedWeapon(IWeaponLogic weapon);
    }

    public class PlayerCharacter : IPlayerCharacter
    {
        public IWeaponLogic UsedWeapon { get; private set; } 

        public void SetEquipedWeapon(IWeaponLogic weapon)
        {
            UsedWeapon = weapon;
        }
    }
}
