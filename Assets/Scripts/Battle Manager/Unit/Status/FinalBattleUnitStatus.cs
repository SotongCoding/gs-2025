namespace SotongStudio
{
    public interface IFinalBattleUnitStatus : IBasicStatusData
    {

    }
    public class FinalBattleUnitStatus : IFinalBattleUnitStatus
    {
        private IBattleUnitStatus _baseStatus;

        private IModifiedBattleUnitStatus _modifiedStatus;

        public FinalBattleUnitStatus(IBattleUnitStatus baseStatus,
                                     IModifiedBattleUnitStatus modifiedStatus)
        {
            _baseStatus = baseStatus;
            _modifiedStatus = modifiedStatus;

        }

        public int Attack => _baseStatus.Attack + _modifiedStatus.Attack;
        public int Defense => _baseStatus.Defense +_modifiedStatus.Defense;
        public int Health => _baseStatus.Health +_modifiedStatus.Health;
    }
}
