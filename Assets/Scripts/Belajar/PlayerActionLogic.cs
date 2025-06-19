using System;
using UnityEngine;

namespace SotongStudio
{
    public class PlayerActionLogic : MonoBehaviour
    {
        public bool IsChantingSpell;
        [SerializeField] private ButtonView _buttonView;
        [SerializeField] private PlayerActionView _playerActionView;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            IsChantingSpell = false;

            _buttonView.OnButtonPedangPressed += _playerActionView.SeranganPedang;
            _buttonView.OnButtonSihirPressed += SeranganSihir;
        }

        private void OnDestroy()
        {
            _buttonView.OnButtonPedangPressed -= _playerActionView.SeranganPedang;
            _buttonView.OnButtonSihirPressed -= SeranganSihir;
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
