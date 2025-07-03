using UnityEngine;

namespace SotongStudio
{
    public interface IStatusData
    {
        int Attack { get; }
        int Defense { get; }
        int Health { get; }

        int PercentageAttack { get; }
        int PercentageDefense { get; }
        int PercentageHealth { get; }
    }
}
