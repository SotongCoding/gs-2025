using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Gambling Stat")]
    public class GamblingStatConfig : BaseSeedBehaviourConfig
    {
        [SerializeField]
        private GamblingMinStatData _minStatData;

        [SerializeField]
        private GamblingMaxStatData _maxStatData;

        public override IUseLogic UseLogic => new GamblingStatLogic(_minStatData, _maxStatData);
        public override IThrowLogic ThrowLogic => new GamblingStatLogic(_minStatData, _maxStatData);
    }
}
