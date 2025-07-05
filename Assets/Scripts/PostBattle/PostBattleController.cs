using Cysharp.Threading.Tasks;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface IPostBattleControlller
    {
        UnityEvent OnDonePostBattle { get; }
        UniTask DoPostBattleSequenceAsync();
    }
    public class PostBattleController : IPostBattleControlller
    {
        public UnityEvent OnDonePostBattle { get; private set; } = new();

        private readonly IObtainSeedLogic _obtainSeedLogic;

        public PostBattleController(IObtainSeedLogic obtainSeedLogic)
        {
            _obtainSeedLogic = obtainSeedLogic;
        }


        public async UniTask DoPostBattleSequenceAsync()
        {
            _obtainSeedLogic.AddSeedToInventory();
            await _obtainSeedLogic.OnDoneObtainSeed.OnInvokeAsync(default);
            _obtainSeedLogic.Hide();
        }
    }
}
