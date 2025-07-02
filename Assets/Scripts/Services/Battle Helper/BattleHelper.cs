namespace SotongStudio
{
    public interface IBattleHelper
    {
        void AddUnitStatus(IUnit executor, StraightStatUpData statUpData);
    }
    public class BattleHelper : IBattleHelper
    {
        public void AddUnitStatus(IUnit executor, StraightStatUpData statUpData)
        {
            executor.AddStat(statUpData);
        }
    }
}
