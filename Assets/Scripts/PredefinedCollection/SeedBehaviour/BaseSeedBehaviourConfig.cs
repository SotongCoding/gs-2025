using SotongStudio.SharedData.PredefinedData;
using UnityEngine;

namespace SotongStudio
{
    public abstract class BaseSeedBehaviourConfig : ScriptableObject, IPredefinedItem
    {
        public string ItemId => BehaviourId;

        [field: SerializeField]
        private string BehaviourId;

        [TextArea]
        public string Description;


        public abstract IUseLogic UseLogic { get; }
        public abstract IThrowLogic ThrowLogic { get; }
    }
}
