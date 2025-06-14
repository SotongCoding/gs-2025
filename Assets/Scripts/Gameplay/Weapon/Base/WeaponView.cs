using UnityEngine;

namespace SotongStudio
{
    public interface IWeaponView
    {
        void DoAttackAnimation();
    }

    public class WeaponView : MonoBehaviour, IWeaponView
    {
        public void DoAttackAnimation()
        {
            Debug.Log("Do Attack Animation");
        }
    }
}
