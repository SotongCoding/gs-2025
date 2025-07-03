using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class GamblingStatLogic : IUseLogic, IThrowLogic
    {
        private GamblingMinStatData _minStatData { get; }
        private GamblingMaxStatData _maxStatData { get; }

        public GamblingStatLogic(GamblingMinStatData minStatData, GamblingMaxStatData maxStatData)
        {
            _minStatData = minStatData;
            _maxStatData = maxStatData;
        }

        UniTask IUseLogic.ExecuteBehaviourAsync(IUnit executor, IUnit reciver, IBattleHelper battleHelper)
        {
            return UniTask.CompletedTask;
        }

        UniTask IThrowLogic.ExecuteBehaviourAsync(IUnit executor, IUnit reciver, IBattleHelper battleHelper)
        {
            return UniTask.CompletedTask;
        }
    }

    [System.Serializable]
    public class GamblingMinStatData : IBasicStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }
        [field: SerializeField]
        public int Defense { get; private set; }
        [field: SerializeField]
        public int Health { get; private set; }
    }

    [System.Serializable]
    public class GamblingMaxStatData : IBasicStatusData
    {
        [field: SerializeField]
        public int Attack { get; private set; }
        [field: SerializeField]
        public int Defense { get; private set; }
        [field: SerializeField]
        public int Health { get; private set; }
    }
}
