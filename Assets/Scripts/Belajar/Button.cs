using System;
using UnityEngine;

namespace SotongStudio
{
    public class Button : MonoBehaviour
    {
        public Action OnButtonPedangPressed;
        public Action OnButtonSihirPressed;

        public void ButtonPedang()
        {
            OnButtonPedangPressed();
        }

        public void ButtonSihir()
        {
            OnButtonSihirPressed();
        }
    }
}
