using System;
using UnityEngine;

namespace SotongStudio
{
    public class ButtonView : MonoBehaviour
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
