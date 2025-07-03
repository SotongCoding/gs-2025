using NaughtyAttributes;
using System;
using UnityEngine;

namespace SotongStudio
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private EnemyConfigCollection _enemyCollection;
        private EnemyConfigData _enemyConfigData;
        [SerializeField] private Vector3 _position;
        private GameObject _instanceObject;
        private int _level = 1;
        private int _index = 8;
        private int _idEnemy = 1;

        private void AssignEnemy()
        {
            _enemyConfigData = _enemyCollection.GetItem($"{_idEnemy}");
        }

        [Button]
        public void SpawnEnemy()
        {
            AssignEnemy();
            _instanceObject = Instantiate(_enemyConfigData.VisualData.VisualPart, _position, Quaternion.identity);

            while (_index >= _level)
            {
                Transform parts = _instanceObject.transform.Find($"Visual Root/{_index}");
                if (parts != null)
                {
                    parts.gameObject.SetActive(false);
                }
                _index--;
            }
            _index = 8;
        }

        [Button]
        private void DestroyEnemy()
        {
            Destroy(_instanceObject);
            IncreaseLevel();
        }

        private void IncreaseLevel()
        {
            if (_level <= 9)
            {
                _level++;
            }
        }

        /*
         * Start battle()
         * After battle()
         * Pokoknya sambung seolah2 bisa battle 9 level
        */
    }
}
