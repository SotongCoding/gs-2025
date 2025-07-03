using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SotongStudio
{
    public interface IUseLogic 
    {
        UniTask ExecuteBehaviourAsync(IUnit executor, IUnit reciver,
                                       IBattleHelper battleHelper);
    }
    public interface IThrowLogic
    {
        UniTask ExecuteBehaviourAsync(IUnit executor, IUnit reciver,
                                      IBattleHelper battleHelper);
    }
}
