using UnityEngine;

namespace SotongStudio
{
    public interface ISeedInventoryView
    {
        void Show();
        void Hide();
    }
    public class SeedInventoryView : MonoBehaviour, ISeedInventoryView
    {
        [SerializeField]
        private CanvasGroup _inventoryCanvas;

        public void Hide()
        {
            _inventoryCanvas.Hide();
        }

        public void Show()
        {
            _inventoryCanvas.Show();
        }
    }
}
