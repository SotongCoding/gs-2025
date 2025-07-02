using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Stealing Stat")]
    public class StealingStatConfig : BaseSeedBehaviourConfig
    {
        [field: SerializeField]
        private StealedStatData _takenStatData;
        public override ISeedBehaviourLogic UseLogic => new StealingStatLogic(_takenStatData);

        public override ISeedBehaviourLogic ThrowLogic => UseLogic;
    }
}
