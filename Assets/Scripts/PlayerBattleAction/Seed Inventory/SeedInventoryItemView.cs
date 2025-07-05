using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
    public class SeedInventoryItemView : MonoBehaviour
    {
        public UnityEvent OnSelectSeed { get; private set; } = new();

        [SerializeField]
        private Toggle _selectToggle;

        private void Awake()
        {
            _selectToggle.onValueChanged.AddListener(SelectSeedProcess);
        }

        private void SelectSeedProcess(bool isOn)
        {
            if (isOn)
            {
                OnSelectSeed.Invoke();
            }
        }
    }
}

