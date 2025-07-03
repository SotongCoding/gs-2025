using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public interface IUseLogic 
    {
        UniTask ExecuteBehaviourAsync(IBattleHelper battleHelper);
    }
    public interface IThrowLogic
    {
        UniTask ExecuteBehaviourAsync(IBattleHelper battleHelper);
    }
}
