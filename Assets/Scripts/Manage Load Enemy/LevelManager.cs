using NaughtyAttributes;
using System;
using UnityEngine;

namespace SotongStudio
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private EnemyConfigData _enemyConfigData;
        [SerializeField] private Vector3 _position;
        private GameObject _instanceObject;
        private int _level = 1;
        private int _index;

        private void Start()
        {
            Debug.Log($"Level {_level}");
            InisiateEnemy();
            SetEnemyParts();
        }

        public void InisiateEnemy()
        {
            _instanceObject = Instantiate(_enemyConfigData.VisualData.VisualPart, _position, Quaternion.identity);
        }

        public void SetEnemyParts()
        {
            _index = 8;
            while (_index > _level-1)
            {
                Transform parts = _instanceObject.transform.Find($"Visual Root/{_index}");
                if (parts != null)
                {
                    parts.gameObject.SetActive(false);
                }
                _index--;
            }
        }

        private void HideEnemy()
        {
            _index = 0;
            while (_index <= _level-1)
            {
                Transform parts = _instanceObject.transform.Find($"Visual Root/{_index}");
                if (parts != null)
                {
                    parts.gameObject.SetActive(false);
                }
                _index++;
            }
        }

        private void ShowEnemy()
        {
            _index = 0;
            while (_index <= _level-1)
            {
                Transform parts = _instanceObject.transform.Find($"Visual Root/{_index}");
                if (parts != null)
                {
                    parts.gameObject.SetActive(true);
                }
                _index++;
            }
        }

        private void IncreaseLevel()
        {
            if (_level <= 9)
            {
                _level++;
            }
        }

        private void ResetLevel()
        {
            if(_level != 0)
            {
                _level = 0;
            }
        }

        private void CombineSeed()
        {
            Debug.Log("Combine Seed");
        }

        private void EnchantSeed()
        {
            Debug.Log("Enchant Seed");
        }

        private void PickASeed()
        {
            Debug.Log("Pick A Seed");
        }

        private void GetASeed()
        {
            Debug.Log("Get A Seed");
        }

        private void AfterBattleActivity()
        {
            if(_level == 9)
            {
                Debug.Log("Game Ended");
                ResetLevel();
            }
            else if(_level % 3 == 0)
            {
                GetASeed();
                EnchantSeed();
            }
            else
            {
                PickASeed();
            }
            CombineSeed();
        }

        [Button]
        private void DefeatEnemy()
        {
            HideEnemy();
            AfterBattleActivity();
        }

        [Button]
        private void FinishAfterBattleActivity()
        {
            IncreaseLevel();
            Debug.Log($"Level {_level}");
            ShowEnemy();
            //SetEnemyParts();
        }
    }
}
