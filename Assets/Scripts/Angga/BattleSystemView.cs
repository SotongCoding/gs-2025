using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;

namespace SotongStudio
{
    public class BattleSystemView : MonoBehaviour
    {
        [SerializeField] private GameObject _preparationUI, _seedUI, _qtaUI;

        public void SetupBattle()
        {
            _preparationUI.SetActive(true);
            _seedUI.SetActive(false);
            _qtaUI.SetActive(false);
        }

        public void StartBattle()
        {
            _preparationUI.SetActive(false);
            _seedUI.SetActive(false);
            Debug.Log("Battle Start");
        }

        public void UseSeed()
        {
            Debug.Log("Player menggunakan seed");
            _seedUI.SetActive(false);
        }

        public void ThrowSeed()
        {
            Debug.Log("Player melempar seed");
            _seedUI.SetActive(false);
        }

        public void SeedSelected()
        {
            _seedUI.SetActive(true);
        }

        public void SetQTA()
        {
            _qtaUI.SetActive(true);
        }

        public void EnemyTurn()
        {
            _qtaUI.SetActive(false);
            Debug.Log("Musuh menyerang");
        }
    }
}
