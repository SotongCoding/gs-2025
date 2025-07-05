using UnityEngine;

namespace SotongStudio
{
    public interface IModifiedBattleUnitStatus : IBasicStatusData
    {
        void AddStat(IBasicStatusData addedStat);
        void Clear();
        void ReduceHealth(int reduceAmount);

    }

    public class ModifiedBattleUnitStat : IModifiedBattleUnitStatus
    {

        private int _attack;

        private int _defense;

        private int _health;

        public ModifiedBattleUnitStat()
        {
        }

        public int Attack => _attack;
        public int Defense => _defense;
        public int Health => _health;

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

        public void Clear()
        {
            _attack = 0;
            _health = 0;
            _defense = 0;
        }
    }
}
