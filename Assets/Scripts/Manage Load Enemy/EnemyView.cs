using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SotongStudio.Unlink.Utilities.AnimatorHelper;
using UnityEngine;
using UnityEngine.Pool;

namespace SotongStudio
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private EnemyConfigData _enemyConfigData;
        [SerializeField] private Animator _animatorController;

        private int _currentHealth;
        private int _currentAttack;
        private int _currentDeffense;

        [SerializeField] private List<GameObject> _enemyParts;
        [SerializeField] private List<SpriteRenderer> _enemySprite;
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

        public UniTask PlayAttackAnimationAsync()
        {
            return _animatorController.PlayAsync("character_attack", default);
        }

        public UniTask PlayIdleAnimationAsync()
        {
            return _animatorController.PlayAsync("character_idle", default);
        }

        public UniTask PlayTakeDamageVFXAsync()
        {
            using var _ = ListPool<UniTask>.Get(out var changeProcess);
            foreach (var item in _enemySprite)
            {
                var colorChange = item.DOColor(Color.red, 0.1f).OnComplete(() =>
                {
                    item.DOColor(Color.white, 0.1f);
                }).AsyncWaitForCompletion().AsUniTask();

                changeProcess.Add(colorChange);
            }

            return UniTask.WhenAll(changeProcess);
        }
    }
}
