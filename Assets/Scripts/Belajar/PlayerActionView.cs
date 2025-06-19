using UnityEngine;

namespace SotongStudio
{
    public class PlayerActionView : MonoBehaviour
    {
        public void SeranganPedang()
        {
            Debug.Log("Player menyerang dengan pedang");
        }

        public void ChantingSpell()
        {
            Debug.Log("Player sedang merapal sihir");
        }

        public void LaunchSpell()
        {
            Debug.Log("Player menyerang dengan sihir");
        }
    }
}
