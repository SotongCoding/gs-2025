namespace SotongStudio
{
    public interface IEnemyUnit : IUnit
    {

    }
    public class EnemyUnit : Unit, IEnemyUnit
    {
        public EnemyUnit(int attack, int defense, int health) : base(attack, defense, health)
        {
        }
    }
}
