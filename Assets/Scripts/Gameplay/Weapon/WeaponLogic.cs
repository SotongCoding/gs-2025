using UnityEngine;

namespace SotongStudio
{
    public interface IWeaponLogic
    {
        void DoAttackProcess();
    }

    public class WeaponLogic : IWeaponLogic
    {
        private readonly IWeaponView _view;
        public void DoAttackProcess()
        {
            _view.DoAttackAnimation();
        }
    }
}
