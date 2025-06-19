using UnityEngine;

namespace SotongStudio
{
    public class GameManager : MonoBehaviour
    {
        private int _currentTurn;
        private int _playerTurn;
        public bool IsPlayerTurn;
        [SerializeField] private GameObject _playerCommand;
        [SerializeField] private TurnService _turnService;
        [SerializeField] private PlayerActionLogic _player;
        [SerializeField] private ButtonView _buttonView;

        private void Start()
        {
            RandomizeTurn();
            _currentTurn = _turnService.TurnAmount;

            _buttonView.OnButtonPedangPressed += ChangeTurn;
            _buttonView.OnButtonSihirPressed += ChangeTurn;
        }

        private void OnDestroy()
        {
            _buttonView.OnButtonPedangPressed -= ChangeTurn;
            _buttonView.OnButtonSihirPressed -= ChangeTurn;
        }

        private void Update()
        {
            NewTurn();

            if (IsPlayerTurn)
            {
                _playerCommand.SetActive(true);
            }
            else
            {
                _playerCommand.SetActive(false);
            }
        }

        private void NewTurn()
        {
            if (_turnService.TurnAmount > _currentTurn)
            {
                _currentTurn++;
                IsPlayerTurn = true;
                if (_player.IsChantingSpell)
                {
                    _player.SeranganSihir();
                    IsPlayerTurn = false;
                }
            }
        }

        private void RandomizeTurn()
        {
            _playerTurn = Random.Range(0, 2);

            if (_turnService.TurnAmount % 2 == _playerTurn)
            {
                IsPlayerTurn = true;
            }
            else IsPlayerTurn = false;
        }

        private void ChangeTurn()
        {
            if (IsPlayerTurn)
            {
                IsPlayerTurn = false;
            }
        }
    }
}
