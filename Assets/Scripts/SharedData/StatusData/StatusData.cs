using System.Runtime.CompilerServices;

namespace SotongStudio
{
    public interface IBasicStatusData
    {
        int Attack { get; }
        int Defense { get; }
        int Health { get; }
    }

    public interface ISpecialStatusData
    {

        int PercentageAttack { get; }
        int PercentageDefense { get; }
        int PercentageHealth { get; }
    }
    public interface IStatusData : IBasicStatusData
    {


    }
}
