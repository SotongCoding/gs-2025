using UnityEngine;

namespace SotongStudio
{
    public class GameManager : MonoBehaviour
    {
        int currentTurn;
        int playerTurn;
        public bool isPlayerTurn;
        [SerializeField] TurnService turnService;
        [SerializeField] GameObject playerCommand;
        [SerializeField] PlayerActionView player;
        [SerializeField] Button button;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            RandomizeTurn();
            currentTurn = turnService.TurnAmount;

            button.OnButtonPedangPressed += ChangeTurn;
            button.OnButtonSihirPressed += ChangeTurn;
        }

        private void OnDestroy()
        {
            button.OnButtonPedangPressed -= ChangeTurn;
            button.OnButtonSihirPressed -= ChangeTurn;
        }

        // Update is called once per frame
        void Update()
        {
            NewTurn();

            if (isPlayerTurn)
            {
                playerCommand.SetActive(true);
            }
            else
            {
                playerCommand.SetActive(false);
            }
        }

        void NewTurn()
        {
            if (turnService.TurnAmount > currentTurn)
            {
                currentTurn++;
                isPlayerTurn = true;
                if (player.isChantingSpell)
                {
                    player.ChantingSpell();
                    isPlayerTurn = false;
                }
            }
        }

        void RandomizeTurn()
        {
            playerTurn = Random.Range(0, 2);

            if (turnService.TurnAmount % 2 == playerTurn)
            {
                isPlayerTurn = true;
            }
            else isPlayerTurn = false;
        }

        void ChangeTurn()
        {
            if (isPlayerTurn)
            {
                isPlayerTurn = false;
            }
        }
    }
}
