using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public interface ISeedBehaviourLogic
    {
        UniTask ExecuteBehaviourAsync(IUnit executor, IUnit reciver,
                                      IBattleHelper battleHelper);       
    }
}
