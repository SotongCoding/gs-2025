using UnityEngine;

namespace SotongStudio
{
    public interface ICharacterUnit : IUnit
    {
        void ResetModifiedStat();
    }
    public class CharacterUnit : Unit, ICharacterUnit
    {
        public CharacterUnit(int attack, int defense, int health) : base(attack, defense, health)
        {
        }

        public void ResetModifiedStat()
        {
            ModifiedStatus.Clear();
        }
    }
}
