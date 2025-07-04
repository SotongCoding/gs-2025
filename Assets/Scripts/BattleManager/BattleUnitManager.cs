using UnityEngine;

namespace SotongStudio
{
    public interface IBattleUnitManager
    {
        ICharacterUnit Character { get; }
        IEnemyUnit Enemy { get; }
        void SetCharacterUnit(ICharacterUnit character);
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

        public void SetEnemyUnit(IEnemyUnit enemy)
        {
            Enemy = enemy;
        }
    }
}
