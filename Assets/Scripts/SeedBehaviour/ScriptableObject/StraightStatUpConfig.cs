using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Straight Stat Up")]
    public class StraightStatUpConfig : BaseSeedBehaviourConfig
    {
        [field: SerializeField]
        private StraightStatUpData _statUpData;
        public override ISeedBehaviourLogic UseLogic => new StraightStatUpLogic(_statUpData);

        public override ISeedBehaviourLogic ThrowLogic => UseLogic;
    }
}
