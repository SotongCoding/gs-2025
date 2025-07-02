using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public class BattleSystemView : MonoBehaviour
    {
        [SerializeField] private GameObject _preparationUI;
        [SerializeField] private GameObject _seedUI;
        [SerializeField] private GameObject _qtaUI;

        public UnityEvent OnDoneQTA { get; private set; } = new();

        private bool _isQTAOn = false;

        private void Update()
        {
            if (_isQTAOn)
            {
                CheckQTAInput();
            }
        }

        public void SetupBattleVisual()
        {
            _preparationUI.SetActive(true);
            _seedUI.SetActive(false);
            _qtaUI.SetActive(false);
        }

        public void HidePreparationUI()
        {
            _preparationUI.SetActive(false);
            _seedUI.SetActive(false);
            Debug.Log("Battle Start");
        }

        public void UseSeedButtonPressed()
        {
            Debug.Log("Player menggunakan seed");
            _seedUI.SetActive(false);
        }

        public void ThrowSeedButtonPressed()
        {
            Debug.Log("Player melempar seed");
            _seedUI.SetActive(false);
        }

        public void ShowSeedDescription()
        {
            _seedUI.SetActive(true);
        }

        public void ShowQTA()
        {
            _qtaUI.SetActive(true);
            _isQTAOn = true;
        }

        public void EnemyAttack()
        {
            _qtaUI.SetActive(false);
            Debug.Log("Musuh menyerang");
        }

        public void CheckQTAInput()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Player berhasil menyerang");
                OnDoneQTA.Invoke();
                _isQTAOn = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Player gagal menyerang");
                OnDoneQTA.Invoke();
                _isQTAOn = false;
            }
        }
    }
}
