#nullable enable

using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{
    public class BattleSystemLogic 
    {
        private readonly IPlayerBattleActionController _battleActionControl;
        private readonly BattleSystemView _view;
        private readonly QuickActionController _quickAction;

        private readonly IBattleUnitManager _unitManager;
        private readonly IBattleHelper _battleHelper;

        private readonly LevelManager _levelManager;

        public BattleSystemLogic(IPlayerBattleActionController playerBattleAction,
                                 BattleSystemView battleSystemView,
                                 QuickActionController qickActionController,
                                 IBattleUnitManager unitManger,
                                 IBattleHelper battleHelper,
                                 LevelManager levelManager)
        {
            _view = battleSystemView;

            _levelManager = levelManager;

            _battleActionControl = playerBattleAction;
            _quickAction = qickActionController;

            _unitManager = unitManger;
            _battleHelper = battleHelper;

            _battleActionControl.OnStartQA.AddListener(StartQuickAction);
            _quickAction.OnDoneQuickAction.AddListener(DoneQuickActionSequence);

            _unitManager.SetCharacterUnit(new CharacterUnit(10, 10, 100000));
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
            EnemyTurnAsync().Forget();
        }

        private async UniTask EnemyTurnAsync()
        {
            DealDamageToCharacter();
            await UniTask.WaitForSeconds(1f);
            BeginNewTurn();
        }

        private void BeginNewTurn()
        {
            StartPlayerTurn();
        }

        public void StartBattle()
        {
            Debug.Log("Start Battle");
            SetupEnemy(_levelManager.CurrentLevel);            

            _battleActionControl.ShowPreBattleUI();

        }

        private void SetupEnemy(int level)
        {
            _levelManager.InisiateEnemy();
            var enemyConfig = _levelManager.GetCurrentEnemyConfig();
            _unitManager.SetEnemyUnit(enemyConfig);
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

        private void DoneQuickActionSequence(bool isQASuccess)
        {
            if (isQASuccess)
            {
                DealDamageToEnemy();
            }

            if (_unitManager.Enemy.IsDead)
            {
                _levelManager.DefeatEnemy();
                DoEndBattleSequence();

                return;
            }

            QTADone();
        }

        private void DoEndBattleSequence()
        {
            if (_levelManager.CurrentLevel >=9)
            {
                Debug.Log("This GAME OVER");
            }
            //Do Player Post Battle
            _levelManager.FinishAfterBattleActivity();
            StartBattle();
        }

        private void DealDamageToEnemy()
        {
            var enemy = _unitManager.Enemy;
            var character = _unitManager.Character;
            var damage = DamageCalculator.GetDamage(character, enemy);

            _battleHelper.GiveDamageToEnemy(damage);
        }

        private void DealDamageToCharacter()
        {
            var enemy = _unitManager.Enemy;
            var character = _unitManager.Character;

            var damage = DamageCalculator.GetDamage(enemy, character);

            _battleHelper.GiveDamageToCharacter(damage);
        }


    }
}
