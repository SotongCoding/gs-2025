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

        UniTask IUseLogic.ExecuteBehaviourAsync(IBattleHelper battleHelper)
        {
            battleHelper.AddStatusToCharacter(new GamblingResultData(_minStatData, _maxStatData));
            return UniTask.CompletedTask;
        }

        UniTask IThrowLogic.ExecuteBehaviourAsync(IBattleHelper battleHelper)
        {
            battleHelper.AddStatusToEnemy(new GamblingResultData(_minStatData, _maxStatData));
            return UniTask.CompletedTask;
        }
    }

    [System.Serializable]
    public class GamblingMinStatData
    {
        [field: SerializeField]
        public int Attack { get; private set; }
        [field: SerializeField]
        public int Defense { get; private set; }
        [field: SerializeField]
        public int Health { get; private set; }
    }

    [System.Serializable]
    public class GamblingMaxStatData
    {
        [field: SerializeField]
        public int Attack { get; private set; }
        [field: SerializeField]
        public int Defense { get; private set; }
        [field: SerializeField]
        public int Health { get; private set; }
    }

    public class GamblingResultData : IBasicStatusData
    {
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Health { get; private set; }

        public GamblingResultData(GamblingMinStatData min, GamblingMaxStatData max)
        {
            Attack = Random.Range(min.Attack, max.Attack);
            Defense = Random.Range(min.Defense, max.Defense); ;
            Health = Random.Range(min.Health, max.Health); ;
        }

    }
}
