using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
    public class GameManagerView : MonoBehaviour
    {
        public UnityEvent OnGameStart => _gameStartButton.onClick;
        [SerializeField]
        private Button _gameStartButton;

        [SerializeField]
        private CanvasGroup _gameOverCanvas;

        public void ShowGameOver()
        {
            _gameOverCanvas.Show();
        }
    }
}
