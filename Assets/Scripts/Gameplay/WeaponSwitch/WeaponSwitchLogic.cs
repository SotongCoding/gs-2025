using System;
using UnityEngine;

namespace SotongStudio
{
    public interface IWeaponSwitchLogic
    {
        void SwitchPlayerWeapon(PlayerWeapon weapon);
    }
    public class WeaponSwitchLogic : IWeaponSwitchLogic, IDisposable
    {
        private readonly IWeaponSwitchView _view;
        private readonly IWeaponLogic _swordWeapon;
        private readonly IWeaponLogic _magicWandWeapon;
        private readonly IPlayerCharacter _playerCharacter;

        private bool _disposedValue;

        public WeaponSwitchLogic(IWeaponSwitchView view,
                                 IPlayerCharacter playerCharacter,
                                 SwordLogic swordWeapon,
                                 MagicWandLogic magicWandWeapon)
        {
            _view = view;
            _swordWeapon = swordWeapon;
            _magicWandWeapon = magicWandWeapon;

            _playerCharacter = playerCharacter;

            _view.OnChangeWeapon.AddListener(SwitchPlayerWeapon);
        }

        public void SwitchPlayerWeapon(PlayerWeapon weapon)
        {
            Debug.Log($"Switching player weapon to: {weapon}");
            switch (weapon)
            {
                case PlayerWeapon.Sword:
                    _playerCharacter.SetEquipedWeapon(_swordWeapon);
                    break;
                case PlayerWeapon.MagicWand:
                    _playerCharacter.SetEquipedWeapon(_magicWandWeapon);
                    break;
                default:
                    break;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _view.OnChangeWeapon.RemoveListener(SwitchPlayerWeapon);
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public enum PlayerWeapon
    {
        Sword,
        MagicWand
    }
}
