using UnityEngine;

namespace SotongStudio
{
    [CreateAssetMenu(fileName = "SBHV-XXX-000", menuName = "Predefine Item / Seed Behaviour / Give and Punish Stat")]
    public class GiveAndPunishConfig : BaseSeedBehaviourConfig
    {
        [field: SerializeField]
        private GivenStatData _givenStat;

        [field: SerializeField]
        private PunishStatData _takenStat;

        public override ISeedBehaviourLogic UseLogic => new GiveAndPunishLogic(_givenStat, _takenStat);

        public override ISeedBehaviourLogic ThrowLogic => UseLogic;
    }
}
