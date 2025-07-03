using NaughtyAttributes;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SotongStudio
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfigData _enemyConfigData;

        private int _currentHealth;

        public void InitializeEnemy(EnemyConfigData data)
        {
            _enemyConfigData = data;
            _currentHealth = _enemyConfigData.StatusData.Health;
            Debug.Log($"{_enemyConfigData.InfoData.EnemyName} appear!");
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
