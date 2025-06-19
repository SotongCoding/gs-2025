using TMPro;
using UnityEngine;

namespace SotongStudio
{
    public class DialogBox : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private GameManager _gameManager;

        private void Update()
        {
            TurnText();
        }

        private void TurnText()
        {
            if (_gameManager.IsPlayerTurn)
            {
                _text.text = "Player turn";
            }
            else
            {
                _text.text = "Enemy turn";
            }
        }
    }
}
