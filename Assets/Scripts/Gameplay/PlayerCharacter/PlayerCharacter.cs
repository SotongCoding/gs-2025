using SotongStudio.VContainer;

namespace SotongStudio
{
    public interface IPlayerCharacter
    {
        IWeaponLogic UsedWeapon { get; }
    }
    [RegisterAs(typeof(IPlayerCharacter))]
    public class PlayerCharacter : IPlayerCharacter
    {
        public IWeaponLogic UsedWeapon { get; private set; } = new MagicWandLogic();

    }
}
