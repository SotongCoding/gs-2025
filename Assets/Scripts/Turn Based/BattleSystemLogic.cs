#nullable enable

using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using VContainer.Unity;

namespace SotongStudio
{
    public class BattleSystemLogic
    {
        private readonly IPlayerBattleActionController _battleActionControl;
        private readonly BattleSystemView _view;
        private readonly QuickActionController _quickAction;
        private readonly BattleVisualEffect _visualEffect;

        private readonly IBattleUnitManager _unitManager;
        private readonly IBattleHelper _battleHelper;

        private readonly IPostBattleControlller _postBattleController;
        private readonly LevelManager _levelManager;

        public UnityEvent<bool> OnGameEnd = new();

        public BattleSystemLogic(IPlayerBattleActionController playerBattleAction,
                                 BattleSystemView battleSystemView,
                                 QuickActionController qickActionController,
                                 IBattleUnitManager unitManger,
                                 IBattleHelper battleHelper,
                                 LevelManager levelManager,
                                 IPostBattleControlller postBattleController,
                                 BattleVisualEffect visualEffect
                                 )
        {
            _view = battleSystemView;

            _levelManager = levelManager;

            _battleActionControl = playerBattleAction;
            _quickAction = qickActionController;

            _unitManager = unitManger;
            _battleHelper = battleHelper;
            _postBattleController = postBattleController;

            _visualEffect = visualEffect;

            _battleActionControl.OnStartQA.AddListener(StartQuickAction);
            _quickAction.OnDoneQuickAction.AddListener(DoneQuickActionSequence);

            _unitManager.SetCharacterUnit(new CharacterUnit(10, 10, 500));

        }

        private void FightButtonPressed()
        {
            _view.HidePreparationUI();
            BeginNewTurn();
        }

        private void ShowSeedDescription()
        {
            _view.ShowSeedDescription();
        }

        private void QTADone()
        {
            BeginNewTurn();
        }

        private async UniTask EnemyTurnAsync()
        {
            Debug.Log("Enemy Turn");
            DealDamageToCharacter();
            await _levelManager.EnemyView.PlayAttackAnimationAsync();
            _levelManager.EnemyView.PlayIdleAnimationAsync().Forget();

        }

        private void BeginNewTurn()
        {
            StartPlayerTurn();
        }

        public void StartBattle()
        {
            Debug.Log("Start Battle");
            SetupEnemy(_levelManager.CurrentLevel);
            ResetModifiedCharacterStat();

            _battleActionControl.ShowPreBattleUI();

        }

        private void ResetModifiedCharacterStat()
        {
            _unitManager.Character.ResetSeedStatus();
        }

        private void SetupEnemy(int level)
        {
            var enemyConfig = _levelManager.GetCurrentEnemyConfig();
            _unitManager.SetEnemyUnit(enemyConfig);
            _levelManager.InisiateEnemy();
            _levelManager.EnemyView.PlayIdleAnimationAsync().Forget();
        }

        private void StartPlayerTurn()
        {
            _battleActionControl.ShowPreBattleUI();
        }

        private void StartQuickAction()
        {
            var enemyConfig = _levelManager.GetCurrentEnemyConfig();
            var qaConfig = enemyConfig.QAData;

            _battleActionControl.HidePreBattleUI();
            _quickAction.StartQuickAction(qaConfig.QADuration, qaConfig.QAAmount);
        }

        void DoneQuickActionSequence(bool isQASuccess)
        {
            DoneQuickActionSequenceAsync(isQASuccess).Forget();
        }

        private async UniTask DoneQuickActionSequenceAsync(bool isQASuccess)
        {
            if (isQASuccess)
            {
                await DealDamageToEnemyAsync();
            }
            else
            {
                await EnemyTurnAsync();
            }

            if (_unitManager.Enemy.IsDead)
            {
                _levelManager.DefeatEnemy();
                DoEndBattleSequenceAsync().Forget();

                return;
            }

            if (_unitManager.Character.IsDead)
            {
                Debug.Log("Character is dead, GAME OVER");
                OnGameEnd.Invoke(false);
                return;
            }
            else
            {

                QTADone();
            }

        }

        private async UniTask DoEndBattleSequenceAsync()
        {
            _view.PlayAfterBattleBGM();

            if (_levelManager.CurrentLevel >= 9)
            {
                OnGameEnd.Invoke(true);
                return;
            }

            await _postBattleController.DoPostBattleSequenceAsync();

            _levelManager.FinishAfterBattleActivity();
            StartBattle();
        }

        private UniTask DealDamageToEnemyAsync()
        {
            var enemy = _unitManager.Enemy;
            var character = _unitManager.Character;
            var damage = DamageCalculator.GetDamage(character, enemy);

            _battleHelper.GiveDamageToEnemy(damage);

            return _levelManager.EnemyView.PlayTakeDamageVFXAsync();
        }

        private void DealDamageToCharacter()
        {

            var enemy = _unitManager.Enemy;
            var character = _unitManager.Character;

            var damage = DamageCalculator.GetDamage(enemy, character);

            _battleHelper.GiveDamageToCharacter(damage);

            _visualEffect.PlayTakeDamageAnimation().Forget();
        }


    }
}
