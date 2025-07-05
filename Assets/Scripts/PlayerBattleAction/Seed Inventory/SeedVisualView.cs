using UnityEngine;

namespace SotongStudio
{
    public class SeedVisualView : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _baseVisualCanvas;

        [SerializeField]
        private CanvasGroup _valorTopPartCanvas;
        [SerializeField]
        private CanvasGroup _valorMiddPartCanvas;
        [SerializeField]
        private CanvasGroup _valorBottPartCanvas;

        [SerializeField]
        private CanvasGroup _wisdomTopPartCanvas;
        [SerializeField]
        private CanvasGroup _wisdomMiddPartCanvas;
        [SerializeField]
        private CanvasGroup _wisdomBottPartCanvas;

        [SerializeField]
        private CanvasGroup _lifeTopPartCanvas;
        [SerializeField]
        private CanvasGroup _lifeMiddPartCanvas;
        [SerializeField]
        private CanvasGroup _lifeBottPartCanvas;

        public void ShowSeedAs(SeedType topPart, SeedType middle, SeedType bottomPart)
        {
            ShowTopPart(topPart);
            ShowMiddPart(middle);
            ShowBottPart(bottomPart);
        }
        private void ShowTopPart(SeedType topPart)
        {
            _valorTopPartCanvas.Hide();
            _wisdomTopPartCanvas.Hide();
            _lifeTopPartCanvas.Hide();

            switch (topPart)
            {
                case SeedType.Valor:
                    _valorTopPartCanvas.Show();
                    break;
                case SeedType.Wisdom:
                    _wisdomTopPartCanvas.Show();
                    break;
                case SeedType.Life:
                    _lifeTopPartCanvas.Show();
                    break;
                default:
                    break;
            }
        }

        private void ShowMiddPart(SeedType midPart)
        {
            _valorMiddPartCanvas.Hide();
            _wisdomMiddPartCanvas.Hide();
            _lifeMiddPartCanvas.Hide();

            switch (midPart)
            {
                case SeedType.Valor:
                    _valorMiddPartCanvas.Show();
                    break;
                case SeedType.Wisdom:
                    _wisdomMiddPartCanvas.Show();
                    break;
                case SeedType.Life:
                    _lifeMiddPartCanvas.Show();
                    break;
                default:
                    break;
            }
        }

        private void ShowBottPart(SeedType botPart)
        {
            _valorBottPartCanvas.Hide();
            _wisdomBottPartCanvas.Hide();
            _lifeBottPartCanvas.Hide();

            switch (botPart)
            {
                case SeedType.Valor:
                    _valorBottPartCanvas.Show();
                    break;
                case SeedType.Wisdom:
                    _wisdomBottPartCanvas.Show();
                    break;
                case SeedType.Life:
                    _lifeBottPartCanvas.Show();
                    break;
                default:
                    break;
            }
        }

        public void HideVisual()
        {
            _baseVisualCanvas.Hide();
        }
        public void ShowVisual()
        {
            _baseVisualCanvas.Show();
        }
    }
}
