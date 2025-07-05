using System.Collections.Generic;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface ICombineSeedLogic
    {
        UnityEvent OnCloseCombinedSeed { get; }
        UnityEvent OnCombineAction { get; }
        void AddSelectedSeed(ISeedData seed);
        void RemoveSeedOnIndex(int index);
        void DoCombineProcess();

        void Show();
        void Hide();
    }
    public class CombineSeedLogic : ICombineSeedLogic
    {
        public UnityEvent OnCloseCombinedSeed => _combineSeedView.OnCombineSeedClose;
        public UnityEvent OnCombineAction => _combineSeedView.OnCombineSeed;

        private readonly ICombineSeedView _combineSeedView;
        private List<ISeedData> _selectedSeeds = new();

        private readonly ISeedDataFactory _dataFactory;
        private readonly IPlayerSeedService _seedService;

        public CombineSeedLogic(ICombineSeedView combineSeedView, 
                                ISeedDataFactory dataFactory,
                                IPlayerSeedService seedService)
        {
            _combineSeedView = combineSeedView;

            _dataFactory = dataFactory;
            _seedService = seedService;
        }

        public void AddSelectedSeed(ISeedData seed)
        {
            if (seed is ICombinedSeed) { return; }
            if (_selectedSeeds.Contains(seed)) 
            {
                _selectedSeeds.Remove(seed);
            }
            else
            {
                _selectedSeeds.Add(seed);
            }

            UpdateSeedVisual();
        }
        public void RemoveSeedOnIndex(int index)
        {
            _selectedSeeds.RemoveAt(index);
        }

        private void UpdateSeedVisual()
        {
            for (int i = 0; i < _selectedSeeds.Count; i++)
            {
                _combineSeedView.SetSeedVisual(i, _selectedSeeds[i].VisualData);
            }
            for (int i = _selectedSeeds.Count; i < 3; i++) //TODO Need refer amount of Seed Slot
            {
                _combineSeedView.SetSeedVisual(i, null);
            }
        }


        public void Hide()
        {
            _combineSeedView.HideCombineSeedUI();
        }
        public void Show()
        {
            _combineSeedView.ShowCombineSeedUI();
        }

        public void DoCombineProcess()
        {
            var combinedSeed = _dataFactory.CreateCombinedSeed(_selectedSeeds);
            _seedService.AddCombinedSeedToInventory(combinedSeed);
            _combineSeedView.ShowCombinedSeedResult(combinedSeed.VisualData);
            _seedService.RemoveSeedFromInventory(_selectedSeeds);

            _selectedSeeds.Clear();
            UpdateSeedVisual();
        }
    }
}
