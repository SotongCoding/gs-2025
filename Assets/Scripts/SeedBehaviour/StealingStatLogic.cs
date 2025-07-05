using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class StealingStatLogic : IUseLogic
    {
        private readonly StealedStatData _stealedStat;
        private readonly EarnStatData _earnStatData;

        //Ambil Stat, kasih ke Unit
        UniTask IUseLogic.ExecuteBehaviourAsync(IBattleHelper battleHelper)
        {
            battleHelper.AddStatusToEnemy(_stealedStat);
            battleHelper.AddStatusToCharacter(_earnStatData);

            return UniTask.CompletedTask;
        }

        public StealingStatLogic(StealedStatData stealedStat, EarnStatData earnStatData)
        {
            _stealedStat = stealedStat;
            _earnStatData = earnStatData;
        }
    }

    [System.Serializable]
    public class StealedStatData : IBasicStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }
    }

    [System.Serializable]
    public class EarnStatData : IBasicStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }
    }
}
