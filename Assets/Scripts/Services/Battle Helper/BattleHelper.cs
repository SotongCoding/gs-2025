namespace SotongStudio
{
    public interface IBattleHelper
    {
        void AddStatusToCharacter(IBasicStatusData statUpData);
        void AddStatusToEnemy(IBasicStatusData statUpData);

        void GiveDamageToCharacter(int damage);
        void GiveDamageToEnemy(int damage);
    }
    public class BattleHelper : IBattleHelper
    {
        private readonly IBattleUnitManager _unitManager;

        public BattleHelper(IBattleUnitManager unitManager)
        {
            _unitManager = unitManager;
        }

        public void GiveDamageToCharacter(int damage)
        {
            var character = _unitManager.Character;
            GiveDamageToUnit(character, damage);
        }

        public void GiveDamageToEnemy(int damage)
        {
            var enemy = _unitManager.Enemy;
            GiveDamageToUnit(enemy, damage);
        }
        public void AddStatusToCharacter(IBasicStatusData statUpData)
        {
            AddUnitStatus(_unitManager.Character, statUpData);
        }

        public void AddStatusToEnemy(IBasicStatusData statUpData)
        {
            AddUnitStatus(_unitManager.Enemy, statUpData);
        }

        private void AddUnitStatus(IUnit executor, IBasicStatusData statUpData)
        {
            executor.AddStat(statUpData);
        }

        private void GiveDamageToUnit(IUnit target, int damage)
        {
            target.TakeDamage(damage);
        }

       
    }
}
