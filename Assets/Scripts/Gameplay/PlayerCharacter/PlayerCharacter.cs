using SotongStudio.Unlink;
using UnityEngine;

namespace SotongStudio
{
    public interface IPlayerCharacter
    {
        IWeaponLogic UsedWeapon { get; }
    }
    public class PlayerCharacter : IPlayerCharacter
    {
        public IWeaponLogic UsedWeapon { get; private set; }

    }
}
