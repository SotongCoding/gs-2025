using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using UnityEngine.Events;
using VContainer.Unity;

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
    public class CombineSeedLogic : ICombineSeedLogic, ITickable
    {
        public UnityEvent OnCloseCombinedSeed => _combineSeedView.OnCombineSeedClose;
        public UnityEvent OnCombineAction => _combineSeedView.OnCombineSeed;

        private readonly ICombineSeedView _combineSeedView;
        private List<ISeedData> _selectedSeeds = new();
        private bool _isShow;
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
            _isShow = false;

            _combineSeedView.HideCombineSeedUI();
            _combineSeedView.ClearResult();
            _selectedSeeds.Clear();
        }
        public void Show()
        {
            UpdateSeedVisual();
            _combineSeedView.ShowCombineSeedUI();

            _isShow = true;
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

        public void Tick()
        {
            if(!_isShow) { return; }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnCloseCombinedSeed.Invoke();
            }
        }
    }
}
