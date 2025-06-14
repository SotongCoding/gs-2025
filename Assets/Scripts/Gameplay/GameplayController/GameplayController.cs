using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class GameplayController : MonoBehaviour
    {
        [Inject]
        private void Inject(ITurnControl turnControl,
                            ICharacterActionControl characterActionControl)
        {
            turnControl.OnTurnChange.AddListener(characterActionControl.DoAttackProcess);

            Debug.Log("Check");
        }
    }
}
