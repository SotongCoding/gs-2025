using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{

    public class BattleSystemLogic : IStartable, ITickable
    {
        readonly ButtonView _buttonView;
        readonly BattleSystemView _view;

        private bool _isQTAOn;

        public BattleSystemLogic(ButtonView buttonView, BattleSystemView battleSystemView)
        {
            this._buttonView = buttonView;
            this._view = battleSystemView;
        }

        void IStartable.Start()
        {
            Debug.Log("Testing");
            _buttonView.SeedSelectedButton.onClick.AddListener(SeedSelected);
            _buttonView.FightButton.onClick.AddListener(FightButtonPressed);
            _buttonView.UseSeedButton.onClick.AddListener(_view.UseSeed);
            _buttonView.ThrowSeedButton.onClick.AddListener(_view.ThrowSeed);
            _isQTAOn = false;
            _view.SetupBattle();
        }

        void ITickable.Tick()
        {
            if (_isQTAOn)
            {
                QTACheck();
            }
        }

        private void FightButtonPressed()
        {
            _view.StartBattle();
            _view.SetQTA();
            _isQTAOn = true;
        }

        private void SeedSelected()
        {
            _view.SeedSelected();
        }

        private void QTACheck()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Player berhasil menyerang");
                EnemyTurnAsync().Forget();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Player gagal menyerang");
                EnemyTurnAsync().Forget();
            }
        }

        public async UniTask EnemyTurnAsync()
        {
            _isQTAOn = false;
            _view.EnemyTurn();
            await UniTask.WaitForSeconds(1f);
            _view.SetQTA();
            _isQTAOn = true;
        }
    }
}
