using SotongStudio.SharedData.PredefinedData;
using UnityEngine;

namespace SotongStudio
{
    public abstract class BaseSeedBehaviourConfig : ScriptableObject, IPredefinedItem
    {
        public string ItemId => BehaviourId;

        [field: SerializeField]
        public string BehaviourId;

        public abstract ISeedBehaviourLogic UseLogic { get; }
        public abstract ISeedBehaviourLogic ThrowLogic { get; }
    }
}
