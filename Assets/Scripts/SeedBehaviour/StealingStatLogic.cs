using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class StealingStatLogic : IUseLogic
    {
        private readonly StealedStatData _stealedStat;

        //Ambil Stat, kasih ke Unit
        UniTask IUseLogic.ExecuteBehaviourAsync(IUnit executor, IUnit reciver, IBattleHelper battleHelper)
        {
            return UniTask.CompletedTask;
        }

        public StealingStatLogic(StealedStatData takenStatData)
        {
            _stealedStat = takenStatData;
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
}
