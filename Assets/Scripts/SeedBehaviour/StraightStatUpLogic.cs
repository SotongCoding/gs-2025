using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public class StraightStatUpLogic : ISeedBehaviourLogic
    {
        private StraightStatUpData _statUpData;

        public StraightStatUpLogic(StraightStatUpData statUpData)
        {
            _statUpData = statUpData;
        }

        public UniTask ExecuteBehaviourAsync(IUnit executor, IUnit reciver, IBattleHelper battleHelper)
        {
            battleHelper.AddUnitStatus(executor, _statUpData);

            // play animasi jika ada
            // Kasih visual effect
            // play sound effect

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
