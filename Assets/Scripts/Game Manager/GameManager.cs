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
        }

        public void Start()
        {
            
        }

        private void GameStart()
        {
            _battleSystem.StartBattle();
        }
    }
}
