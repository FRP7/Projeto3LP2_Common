using System;
using System.Collections.Generic;
using Random = System.Random; // testar
using UnityEngine; // testar
using URand = UnityEngine.Random; // testar

namespace Common
{
    public class GameState
    {
        public Board board;
        private AITurn aiTurn;

        // Cor do jogador.
        public SlotColors PlayerType
        {
            get => board.PlayerType;
            set => board.PlayerType = value;
        }


        // Todas as peças.
        public List<Tuple<SlotTypes, SlotColors>> AllSlots
        {
            get => board.AllSlots;
            set => board.AllSlots = value;
        }

        // Coleção de jogadas possíveis para o jogador.
        public ICollection<SlotTypes> PlayerLegalPlays { get; private set; }

        // Coleção de jogadas possíveis para a AI.
        public ICollection<SlotTypes> AILegalPlays { get; private set; }

        public bool IsPlayerFirst { get; set; }

        // Delegate do gameloop.
        public delegate void GameLoop();

        private GameLoop gameLoop;

        public void Start()
        {
            // Inicializar o tabileiro.
            board.Start();

            GlobalLoop();
            // Ver quem começa primeiro.
            if (WhoStartsFirst())
            {
                IsPlayerFirst = true;
            }
            else
            {
                IsPlayerFirst = false;
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

            if (random.Next(0, 2) == 1)
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

        // Loop que vai sempre acontecer seja quem for o primeiro a jogar.
        public void GlobalLoop()
        {
            gameLoop += board.Update;
            gameLoop += CheckAILegalPlays;
            gameLoop += aiTurn.AIPlay;
            gameLoop += board.Update;
            gameLoop += CheckPlayerLegalPlays;
        }

        private void CheckPlayerLegalPlays()
        {
            Debug.Log("Verificar jogadas possíveis do jogador");
            // slot 0
        }

        private void CheckAILegalPlays()
        {
            Debug.Log("Verificar jogadas possíveis da Ai");
        }

        public GameState()
        {
            board = new Board();
            aiTurn = new AITurn();
            PlayerLegalPlays = new List<SlotTypes>();
            AILegalPlays = new List<SlotTypes>();
        }
    }
}
