namespace SotongStudio
{
    public class SeedVisualControl
    {
        private SeedVisualView _view;

        public SeedVisualControl(SeedVisualView view)
        {
            _view = view;
        }

        public void ShowSeedAs(SeedType topPart, SeedType middle, SeedType bottomPart)
        {
            _view.ShowTopPart(topPart);
            _view.ShowMiddPart(middle);
            _view.ShowBottPart(bottomPart);
        }

        public void HideVisual()
        {
            _view.HideVisual();
        }
    }
}
