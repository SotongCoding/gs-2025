using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class StraightStatUpLogic : IUseLogic, IThrowLogic
    {
        private StraightStatUpData _statUpData;

        public StraightStatUpLogic(StraightStatUpData statUpData)
        {
            _statUpData = statUpData;
        }

        // Ganti Stat Langsung
        public UniTask ExecuteBehaviourAsync(IUnit executor, IUnit reciver, IBattleHelper battleHelper)
        {
            battleHelper.AddUnitStatus(executor, _statUpData);

            return UniTask.CompletedTask;
        }
    }

    [System.Serializable]
    public class StraightStatUpData : IBasicStatusData
    {
        [field:SerializeField]
        public int Attack { get; private set; }

        [field: SerializeField]
        public int Defense { get; private set; }

        [field: SerializeField]
        public int Health { get; private set; }
    }
}
