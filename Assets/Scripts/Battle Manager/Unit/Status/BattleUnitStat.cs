namespace SotongStudio
{
    public interface IBattleUnitStatus : IBasicStatusData
    {

    }

    public class BattleUnitStat : IBattleUnitStatus
    {
        private int _attack;
        public int Attack => _attack;

        private int _defense;
        public int Defense => _defense;

        private int _health;
        public int Health => _health;

        public BattleUnitStat(int attack, int defense, int health)
        {
            _attack = attack;
            _defense = defense;
            _health = health;
        }
    }
}
