using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface IWeaponSwitchView
    {
        UnityEvent<PlayerWeapon> OnChangeWeapon { get; }
    }
    public class WeaponSwitchView : MonoBehaviour, IWeaponSwitchView
    {
        public UnityEvent<PlayerWeapon> OnChangeWeapon { get; private set; } = new();


        [Button]
        private void ChangeToSword()
        {
            OnChangeWeapon?.Invoke(PlayerWeapon.Sword);
        }
        [Button]
        private void ChangeToMagicWand()
        {
            OnChangeWeapon?.Invoke(PlayerWeapon.MagicWand);
        }
    }
}
