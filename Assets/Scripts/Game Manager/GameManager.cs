using System;
using UnityEngine;
using VContainer.Unity;

namespace SotongStudio
{
    public class GameManager : IStartable
    {
        private readonly GameManagerView _view;
        private readonly BattleSystemLogic _battleSystem;
        public GameManager(GameManagerView view, 
                           BattleSystemLogic battleSystem)
        {
            _view = view;

            view.OnGameStart.AddListener(GameStart);
            _battleSystem = battleSystem;

            _battleSystem.OnGameEnd.AddListener(DecideEndGame);
        }

        private void DecideEndGame(bool arg0)
        {
            GameOver();
        }

        public void Start()
        {
            
        }

        public void GameOver()
        {
            _view.ShowGameOver();
        }

        private void GameStart()
        {
            _battleSystem.StartBattle();
        }
    }
}
