using System;
using UnityEngine;

namespace SotongStudio
{
    public class DamageCalculator
    {
        public static int GetDamage(IUnit executor, IUnit reciever)
        {
            var ex_attack = executor.FinalStatus.Attack; 
            var rec_defense = reciever.FinalStatus.Defense;

            var damageRecieve = ex_attack - rec_defense;

            return Mathf.Clamp(damageRecieve, 1, int.MaxValue);
        }
    }
}
