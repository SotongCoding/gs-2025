using System;
using UnityEngine;

namespace SotongStudio
{
    public class SeedButton : MonoBehaviour
    {
        public Action OnButtonPressed;

        public void OnSeedButtonPressed()
        {
            OnButtonPressed();
        }
    }
}
