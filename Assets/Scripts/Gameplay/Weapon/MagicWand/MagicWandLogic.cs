namespace SotongStudio
{
    public class MagicWandLogic : WeaponLogic, IChargedWeapon
    {
        public MagicWandLogic(IWeaponView view) : base(view)
        {
        }

        public int ChargeDuration => 3;
    }
}
