using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class GameplayWeaponScope : ScopeInstallHelper
    {
        [SerializeField]
        private WeaponView _weaponView;
        [SerializeField]
        private WeaponSwitchView _weaponSwitch;

        public override void Install(IContainerBuilder builder)
        {

            builder.Register<SwordLogic>(Lifetime.Singleton);
            //.WithParameter(_weaponView);
            builder.Register<MagicWandLogic>(Lifetime.Singleton);
            //.WithParameter(_weaponView);

            builder.Register<WeaponView>(Lifetime.Singleton).As<IWeaponView>();

            builder.Register<WeaponSwitchLogic>(Lifetime.Singleton).As<IWeaponSwitchLogic>();
            builder.RegisterInstance(_weaponSwitch).As<IWeaponSwitchView>();
        }
    }
}
