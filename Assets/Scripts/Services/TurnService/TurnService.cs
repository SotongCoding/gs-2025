using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio.Unlink
{
    public interface ITurnControl
    {
        public int TurnAmount { get; }
        UnityEvent OnTurnChange { get; }
    }

    public class TurnService : MonoBehaviour, ITurnControl
    {

        public int TurnAmount { get; private set; } = 0;
        public UnityEvent OnTurnChange { get; private set; } = new();

        private bool _disposedValue;

        private void IncrementTurn()
        {
            TurnAmount++;
            OnTurnChange.Invoke();
        }

#if UNITY_EDITOR

        [Button]
        private void SimulateChangeTurn()
        {
            IncrementTurn();
        }
#endif
    }
}
