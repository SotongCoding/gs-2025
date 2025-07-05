using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio
{
    public class BattleVisualEffect : MonoBehaviour
    {
        [SerializeField]
        private Image _damageVintage;

        public UniTask PlayTakeDamageAnimation()
        {
            _damageVintage.color = Color.red;
            return _damageVintage.DOFade(0, 0.2f)                
                .AsyncWaitForCompletion()
                .AsUniTask();
        }
    }
}
