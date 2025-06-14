using System;
using UnityEngine;

namespace SotongStudio
{
    public class PlayerActionView : MonoBehaviour
    {
        public bool isChantingSpell;
        [SerializeField] Button button;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            isChantingSpell = false;

            button.OnButtonPedangPressed += SeranganPedang;
            button.OnButtonSihirPressed += ChantingSpell;
        }

        private void OnDestroy()
        {
            button.OnButtonPedangPressed -= SeranganPedang;
            button.OnButtonSihirPressed -= ChantingSpell;
        }

        void SeranganPedang()
        {
            Debug.Log("Player menyerang dengan pedang");
        }

        public void ChantingSpell()
        {
            if (isChantingSpell)
            {
                Debug.Log("Player menyerang dengan sihir");
                isChantingSpell = false;
            }
            else
            {
                Debug.Log("Player sedang merapal sihir");
                isChantingSpell = true;
            }
        }
    }
}
