using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{

    public class BattleSystemLogic : IStartable
    {
        private readonly PlayerActionView _playerActionView;
        private readonly BattleSystemView _view;

        public BattleSystemLogic(PlayerActionView playerActionView, BattleSystemView battleSystemView)
        {
            this._playerActionView = playerActionView;
            this._view = battleSystemView;

            _playerActionView.SeedSelectedButton.onClick.AddListener(ShowSeedDescription);
            _playerActionView.FightButton.onClick.AddListener(FightButtonPressed);
            _playerActionView.UseSeedButton.onClick.AddListener(_view.UseSeedButtonPressed);
            _playerActionView.ThrowSeedButton.onClick.AddListener(_view.ThrowSeedButtonPressed);

            _view.OnDoneQTA.AddListener(QTADone);
        }

        void IStartable.Start()
        {
            _view.SetupBattleVisual();
        }

        private void FightButtonPressed()
        {
            _view.HidePreparationUI();
            NextTurn();
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
            _view.EnemyAttack();
            await UniTask.WaitForSeconds(1f);
            NextTurn();
        }

        private void NextTurn()
        {
            _view.ShowQTA();
        }
    }
}
