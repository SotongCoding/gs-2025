using NaughtyAttributes;
using System;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{
    public class LevelManager : IStartable
    {
        private readonly EnemyConfigCollection _enemyConfigCollection;
        private readonly BattleSystemView _battleSystemView;

        private EnemyConfigData _enemyConfigData;
        private GameObject _instanceObject;
        private int _level = 1;

        private EnemyView _enemyView;

        public LevelManager(EnemyConfigCollection enemyConfigCollection, BattleSystemView battleSystemView)
        {
            this._enemyConfigCollection = enemyConfigCollection;
            this._battleSystemView = battleSystemView;

            _battleSystemView.OnDefeatEnemy.AddListener(DefeatEnemy);
            _battleSystemView.OnFinishAfterBattleActivity.AddListener(FinishAfterBattleActivity);
        }

        void IStartable.Start()
        {
            Debug.Log($"Level {_level}");
            InisiateEnemy();
            _enemyView.SetEnemyParts(_level);
            _enemyConfigCollection.GetItem($"{_level}");
        }

        public void InisiateEnemy()
        {
            _enemyConfigData = _enemyConfigCollection.GetItem($"{_level}");
            _instanceObject = UnityEngine.Object.Instantiate(_enemyConfigData.VisualData.VisualPart, Vector3.zero, Quaternion.identity);
            _enemyView = _instanceObject.GetComponent<EnemyView>();
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

        private void DefeatEnemy()
        {
            _enemyView.HideEnemy(_level);
            AfterBattleActivity();
        }

        private void FinishAfterBattleActivity()
        {
            IncreaseLevel();
            Debug.Log($"Level {_level}");
            _enemyView.ShowEnemy(_level);
        }
    }
}
