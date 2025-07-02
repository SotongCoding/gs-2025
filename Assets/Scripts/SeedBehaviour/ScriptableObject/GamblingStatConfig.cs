using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Gambling Stat")]
    public class GamblingStatConfig : BaseSeedBehaviourConfig
    {
        [Header("Use")]
        [SerializeField]
        private GamblingMinStatData _useMinStatData;

        [SerializeField]
        private GamblingMaxStatData _useMaxStatData;

        [Header("Throw")]

        [SerializeField]
        private GamblingMinStatData _throwMinStatData;

        [SerializeField]
        private GamblingMaxStatData _throwMaxStatData;

        public override ISeedBehaviourLogic UseLogic => new GamblingStatLogic(_useMinStatData, _useMaxStatData);

        public override ISeedBehaviourLogic ThrowLogic => new GamblingStatLogic(_throwMinStatData, _throwMaxStatData);
    }
}
