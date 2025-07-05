using UnityEngine;

namespace SotongStudio
{
    public interface ICharacterUnit : IUnit
    {
    }
    public class CharacterUnit : Unit, ICharacterUnit
    {
        public CharacterUnit(int attack, int defense, int health) : base(attack, defense, health)
        {
        }
    }
}
