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

        public override IUseLogic UseLogic => throw new System.InvalidOperationException($"Trying Use {nameof(GiveAndPunishLogic)} for Use Logic");

        public override IThrowLogic ThrowLogic => new GiveAndPunishLogic(_givenStat, _takenStat);
    }
}
