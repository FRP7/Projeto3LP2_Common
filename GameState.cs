using System;
using Random = System.Random; // testar
using UnityEngine; // testar
using URand = UnityEngine.Random; // testar

namespace Common
{
    public class GameState
    {
        private Board board;
        private AITurn aiTurn;
        private PlayerTurn playerTurn;

        // Cor do jogador.
        public SlotTypes PlayerType { get => board.PlayerType; set => board.PlayerType = value; }

        // Cores das peças.
        public SlotTypes[] GetSlotTypes { get => board.GetSlotTypes; set => board.GetSlotTypes = value; }

        // Delegate do gameloop.
        public delegate void GameLoop();

        private GameLoop gameLoop;

        public void Start()
        {
            // Inicializar o tabileiro.
            board.Start();

            // Ver quem começa primeiro.
            if(WhoStartsFirst())
            {
                PlayerFirst();
            }
            else
            {
                AIFirst();
            }
        }

        public void Update()
        {
            gameLoop.Invoke();
        }

        // TRUE: jogador  FALSE: AI
        private bool WhoStartsFirst()
        {
            Random random = new Random();

            if(random.Next(0, 2) == 1)
            {
                Debug.Log("Jogador começa primeiro.");
                return true;
            }
            else
            {
                Debug.Log("AI começa primeiro.");
                return false;
            }
        }

        // Definir o gameloop caso a AI comece primeiro.
        private void AIFirst()
        {
            gameLoop += aiTurn.AIPlay;
            gameLoop += board.Update;
            gameLoop += playerTurn.PlayerPlay;
            gameLoop += board.Update;
        }

        // Definir o gameloop caso o jogador comece primeiro.
        private void PlayerFirst()
        {
            gameLoop += playerTurn.PlayerPlay;
            gameLoop += board.Update;
            gameLoop += aiTurn.AIPlay;
            gameLoop += board.Update;
        }

        public GameState()
        {
            board = new Board();
            aiTurn = new AITurn();
            playerTurn = new PlayerTurn();
        }
    }
}
