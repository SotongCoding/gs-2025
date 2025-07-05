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

        [SerializeField] private List<GameObject> _enemyParts;
        private int _index;

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

        public void SetEnemyParts(int level)
        {
            _index = 8;
            while (_index > level - 1)
            {
                if (_enemyParts[_index] != null)
                {
                    _enemyParts[_index].SetActive(false);
                }
                _index--;
            }
        }
        public void HideEnemy(int level)
        {
            _index = 0;
            while (_index <= level - 1)
            {
                if (_enemyParts[_index] != null)
                {
                    _enemyParts[_index].SetActive(false);
                }
                _index++;
            }
        }

        public void ShowEnemy(int level)
        {
            _index = 0;
            while (_index <= level - 1)
            {
                if (_enemyParts[_index] != null)
                {
                    _enemyParts[_index].gameObject.SetActive(true);
                }
                _index++;
            }
        }
    }
}
