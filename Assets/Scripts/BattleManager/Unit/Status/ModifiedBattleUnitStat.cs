using UnityEngine;

namespace SotongStudio
{
    public interface IModifiedBattleUnitStatus : IBasicStatusData
    {
        IBattleUnitStatus BaseStatus { get; }

        void AddStat(IBasicStatusData addedStat);
        void ReduceHealth(int reduceAmount);

    }

    public class ModifiedBattleUnitStat : IModifiedBattleUnitStatus
    {
        public IBattleUnitStatus BaseStatus { get; private set; }

        private int _attack;

        private int _defense;

        private int _health;

        public ModifiedBattleUnitStat(IBattleUnitStatus baseStatus)
        {
            BaseStatus = baseStatus;
        }

        public int Attack => BaseStatus.Attack + _attack;
        public int Defense => BaseStatus.Defense + _defense;
        public int Health => BaseStatus.Health + _health;

        public void AddStat(IBasicStatusData addedStat)
        {
            _attack += addedStat.Attack;
            _defense += addedStat.Defense;
            _health += addedStat.Health;
        }

        public void ReduceHealth(int damage)
        {
            _health -= damage;
        }
    }
}
