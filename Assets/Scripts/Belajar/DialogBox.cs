using TMPro;
using UnityEngine;

namespace SotongStudio
{
    public class DialogBox : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] GameManager gameManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            TurnText();
        }
        
        void TurnText()
        {
            if (gameManager.isPlayerTurn)
            {
                text.text = "Player turn";
            }
            else
            {
                text.text = "Enemy turn";
            }
        }
    }
}
