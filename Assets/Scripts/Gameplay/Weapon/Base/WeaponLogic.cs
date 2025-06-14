using UnityEngine;

namespace SotongStudio
{
    public interface IWeaponLogic
    {
        void DoAttackProcess();
    }

    public abstract class WeaponLogic : IWeaponLogic
    {
        private readonly IWeaponView _view;

        protected WeaponLogic(IWeaponView view)
        {
            _view = view;
        }

        public void DoAttackProcess()
        {
            _view.DoAttackAnimation();

            Debug.Log($"{GetType().Name} attack process started.");
        }
    }
}
