using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Stealing Stat")]
    public class StealingStatConfig : BaseSeedBehaviourConfig
    {
        [field: SerializeField]
        private StealedStatData _takenStatData;
        public override IUseLogic UseLogic => new StealingStatLogic(_takenStatData);
        public override IThrowLogic ThrowLogic => throw new System.InvalidOperationException($"Trying Use {nameof(StealingStatLogic)} for Throw Logic");
    }
}
