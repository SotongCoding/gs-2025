using System;
using UnityEngine;

namespace SotongStudio
{
    public interface IBattleUnitManager
    {
        ICharacterUnit Character { get; }
        IEnemyUnit Enemy { get; }
        void SetCharacterUnit(ICharacterUnit character);
        void SetEnemyUnit(EnemyConfigData enemyData);

        [Obsolete("For Testing Only")]
        void SetEnemyUnit(IEnemyUnit enemy);
    }
    public class BattleUnitManager : IBattleUnitManager
    {
        public ICharacterUnit Character { get; private set; }
        public IEnemyUnit Enemy { get; private set; }

        public void SetCharacterUnit(ICharacterUnit character)
        {
            Character = character;
        }

        public void SetEnemyUnit(EnemyConfigData enemyData)
        {
            Enemy = new EnemyUnit(
                enemyData.StatusData.Attack,
                enemyData.StatusData.Defense,
                enemyData.StatusData.Health
            );
        }

        [Obsolete("For Testing Only")]
        public void SetEnemyUnit(IEnemyUnit enemy)
        {
            Enemy = new EnemyUnit(
               enemy.FinalStatus.Attack,
               enemy.FinalStatus.Defense,
               enemy.FinalStatus.Health
           );
        }
    }
}
