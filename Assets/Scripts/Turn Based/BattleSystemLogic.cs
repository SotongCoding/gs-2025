using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{

    public class BattleSystemLogic : IStartable
    {
        private readonly ButtonView _buttonView;
        private readonly BattleSystemView _view;

        public BattleSystemLogic(ButtonView buttonView, BattleSystemView battleSystemView)
        {
            this._buttonView = buttonView;
            this._view = battleSystemView;

            _buttonView.SeedSelectedButton.onClick.AddListener(SeedSelected);
            _buttonView.FightButton.onClick.AddListener(FightButtonPressed);
            _buttonView.UseSeedButton.onClick.AddListener(_view.UseSeedButtonPressed);
            _buttonView.ThrowSeedButton.onClick.AddListener(_view.ThrowSeedButtonPressed);

            _view.OnDoneQTA.AddListener(QTADone);
        }

        void IStartable.Start()
        {
            Debug.Log("Testing");
            _view.SetupBattleVisual();
        }

        private void FightButtonPressed()
        {
            _view.HidePreparationUI();
            NextTurn();
        }

        private void SeedSelected()
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
