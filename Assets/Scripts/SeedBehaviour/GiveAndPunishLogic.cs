using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class GiveAndPunishLogic : IThrowLogic
    {

        private readonly GivenStatData _givenStat;
        private readonly PunishStatData _takenStat;

        public GiveAndPunishLogic(GivenStatData givenStat, PunishStatData takenStat)
        {
            _givenStat = givenStat;
            _takenStat = takenStat;
        }

        UniTask IThrowLogic.ExecuteBehaviourAsync(IBattleHelper battleHelper)
        {
            battleHelper.AddStatusToEnemy(_givenStat);
            battleHelper.AddStatusToEnemy(_takenStat);

            return UniTask.CompletedTask;
        }
    }

    [System.Serializable]
    public class GivenStatData : IBasicStatusData
    {

        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }
    }

    [System.Serializable]
    public class PunishStatData : IBasicStatusData
    {

        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }
    }
}
