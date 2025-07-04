using NaughtyAttributes;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyConfigData _enemyConfigData;

        private int _currentHealth;
        private int _currentAttack;
        private int _currentDeffense;

        public void InitializeEnemy(EnemyConfigData data)
        {
            _enemyConfigData = data;
            _currentHealth = _enemyConfigData.StatusData.Health;
            _currentAttack = _enemyConfigData.StatusData.Attack;
            _currentDeffense = _enemyConfigData.StatusData.Defense;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            if(_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log($"{_enemyConfigData.InfoData.EnemyName} has died");
        }
    }
}
