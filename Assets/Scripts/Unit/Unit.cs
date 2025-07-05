namespace SotongStudio
{
    public interface IUnit
    {
        IBattleUnitStatus BaseUnitStat { get; }
        IModifiedBattleUnitStatus ModifiedStatus { get; }
        IFinalBattleUnitStatus FinalStatus { get; }
        void AddStat(IBasicStatusData statUpData) => ModifiedStatus.AddStat(statUpData);
        void TakeDamage(int damage);
        bool IsDead => ModifiedStatus.Health <= 0;
    }

    public class Unit : IUnit
    {
        public IBattleUnitStatus BaseUnitStat { get; private set; }
        public IModifiedBattleUnitStatus ModifiedStatus { get; private set; }

        public IFinalBattleUnitStatus FinalStatus { get; private set; }

        public Unit(int attack, int defense, int health)
        {
            BaseUnitStat = new BattleUnitStat(attack, defense, health);
            ModifiedStatus = new ModifiedBattleUnitStat(BaseUnitStat);
            FinalStatus = new FinalBattleUnitStatus(BaseUnitStat, ModifiedStatus);
        }

        public void AddStat(IBasicStatusData statUpData) => ModifiedStatus.AddStat(statUpData);
        public void TakeDamage(int damage)
        {
            ModifiedStatus.ReduceHealth(damage);
        }
    }
}
