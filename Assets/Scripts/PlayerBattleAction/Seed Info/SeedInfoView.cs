using TMPro;
using UnityEngine;

namespace SotongStudio
{
    public interface ISeedInfoView
    {
        void SetThrowInfoText(string useInfoText);
        void SetUseInfoText(string useInfoText);
    }
    public class SeedInfoView : MonoBehaviour, ISeedInfoView
    {
        [SerializeField]
        private TMP_Text _useText;
        
        [SerializeField]
        private TMP_Text _throwText;
        public void SetThrowInfoText(string useInfoText)
        {
            _throwText.text = useInfoText;
        }

        public void SetUseInfoText(string useInfoText)
        {
            _useText.text = useInfoText;
        }
    }
}
