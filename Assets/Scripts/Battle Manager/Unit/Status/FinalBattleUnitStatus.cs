namespace SotongStudio
{
    public interface IFinalBattleUnitStatus : IBasicStatusData
    {

    }
    public class FinalBattleUnitStatus : IFinalBattleUnitStatus
    {
        private IBattleUnitStatus _baseStatus;

        private IModifiedBattleUnitStatus _modifiedStatus;
        private IModifiedBattleUnitStatus _seedStatus;

        public FinalBattleUnitStatus(IBattleUnitStatus baseStatus,
                                     IModifiedBattleUnitStatus modifiedStatus,
                                     IModifiedBattleUnitStatus seedStatus)
        {
            _baseStatus = baseStatus;
            _modifiedStatus = modifiedStatus;
            _seedStatus = seedStatus;

        }

        public int Attack => _baseStatus.Attack + _modifiedStatus.Attack + _seedStatus.Attack;
        public int Defense => _baseStatus.Defense +_modifiedStatus.Defense + _seedStatus.Defense;
        public int Health => _baseStatus.Health + _modifiedStatus.Health + _seedStatus.Health;
    }
}
