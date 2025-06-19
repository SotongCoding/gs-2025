using System;
using UnityEngine;

namespace SotongStudio
{
    public class PlayerActionLogic : MonoBehaviour
    {
        public bool IsChantingSpell;
        [SerializeField] private ButtonView _buttonView;
        [SerializeField] private PlayerActionView _playerActionView;
        private GameManager _gameManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            IsChantingSpell = false;

            _buttonView.OnButtonPedangPressed += _playerActionView.SeranganPedang;
            _buttonView.OnButtonPedangPressed += _gameManager.ChangeTurn;
            _buttonView.OnButtonSihirPressed += SeranganSihir;
            _buttonView.OnButtonSihirPressed += _gameManager.ChangeTurn;
        }

        private void OnDestroy()
        {
            _buttonView.OnButtonPedangPressed -= _playerActionView.SeranganPedang;
            _buttonView.OnButtonPedangPressed -= _gameManager.ChangeTurn;
            _buttonView.OnButtonSihirPressed -= SeranganSihir;
            _buttonView.OnButtonSihirPressed -= _gameManager.ChangeTurn;
        }

        public void SeranganSihir()
        {
            if (IsChantingSpell)
            {
                _playerActionView.LaunchSpell();
                IsChantingSpell = false;
            }
            else
            {
                _playerActionView.ChantingSpell();
                IsChantingSpell = true;
            }
        }
        

        
    }
}
