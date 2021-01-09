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
        public List<Tuple<SlotTypes, SlotColors>> PlayerLegalPlays { get; private set; }

        // Coleção de jogadas possíveis para a AI.
        public List<Tuple<SlotTypes, SlotColors>> AILegalPlays { get; private set; }

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
            gameLoop += aiTurn.AIPlay;
            gameLoop += board.Update;
        }

        public bool CheckPlayerLegalPlays(int piece)
        {
            Debug.Log("Verificar jogadas possíveis do jogador");

            bool isLegal = false;

            // verificar peça 0
            if (piece == 0)
            {
                if (AllSlots[0].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.AI
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[5]);
                    }
                    if (AllSlots[1].Item1 == SlotTypes.AI
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[2]);
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[1]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar peça 1
            if (piece == 1)
            {
                if (AllSlots[1].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[4].Item1 == SlotTypes.AI
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[4]);
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[0]);
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[2]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar peça 2
            if (piece == 2)
            {
                if (AllSlots[2].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[1].Item1 == SlotTypes.AI
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[0]);
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[1]);
                    }
                    if (AllSlots[3].Item1 == SlotTypes.AI &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[3]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar peça 3
            if (piece == 3)
            {
                if (AllSlots[3].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[2]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[5]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[4]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar peça 4
            if (piece == 4)
            {
                if (AllSlots[4].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[8]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[5]);
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[3]);
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[1]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar peça 5
            if (piece == 5)
            {
                if (AllSlots[5].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[7]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[3]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[4]);
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[0]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 6
            if (piece == 6)
            {
                if (AllSlots[6].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.AI
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[0]);
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[5]);
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[1]);
                    }

                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[4]);
                    }

                    if (AllSlots[3].Item1 == SlotTypes.AI
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[2]);
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[3]);
                    }

                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[12]);
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[7]);
                    }

                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[8]);
                    }

                    if (AllSlots[9].Item1 == SlotTypes.AI
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[10]);
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }

                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 7
            if (piece == 7)
            {
                if (AllSlots[7].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[12]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[8]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[5]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 8
            if (piece == 8)
            {
                if (AllSlots[8].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[7]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[4]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 9
            if (piece == 9)
            {
                if (AllSlots[9].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[8]);
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[10]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[7]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[3]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 10
            if (piece == 10)
            {
                if (AllSlots[10].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[12]);
                    }
                    if (AllSlots[9].Item1 == SlotTypes.AI
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 11
            if (piece == 11)
            {
                if (AllSlots[11].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            // verificar a peça 12
            if (piece == 12)
            {
                if (AllSlots[12].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[10]);
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }

            return isLegal;
        }



        private void CheckAILegalPlays()
        {
            Debug.Log("Verificar jogadas possíveis da AI");

            List<SlotTypes> pieces = new List<SlotTypes>();

            // verificar peça 0
            if (AllSlots[0].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[5].Item1 == SlotTypes.Player
                    && AllSlots[6].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[5].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[5]);
                }
                if (AllSlots[1].Item1 == SlotTypes.Player
                    && AllSlots[2].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[2]);
                }
                if (AllSlots[1].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[1]);
                }
            }

            // verificar peça 1
            if (AllSlots[1].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[4].Item1 == SlotTypes.Player
                    && AllSlots[6].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[4].Item1 == SlotTypes.None)
                {
                    AILegalPlays.Add(AllSlots[4]);
                }
                if (AllSlots[0].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[0]);
                }
                if (AllSlots[2].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[2]);
                }
            }

            // verificar peça 2
            if (AllSlots[2].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[1].Item1 == SlotTypes.Player
                    && AllSlots[0].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[0]);
                }
                if (AllSlots[1].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[1]);
                }
                if (AllSlots[3].Item1 == SlotTypes.Player &&
                    AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[3].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[3]);
                }
            }

            // verificar peça 3
            if (AllSlots[3].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[6].Item1 == SlotTypes.Player
                    && AllSlots[9].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[9]);
                }
                if (AllSlots[2].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[2]);
                }
                if (AllSlots[4].Item1 == SlotTypes.Player &&
                    AllSlots[5].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[5]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[4].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[4]);
                }
            }

            // verificar peça 4
            if (AllSlots[4].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[6].Item1 == SlotTypes.Player
                    && AllSlots[8].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[8]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[5].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[5]);
                }
                if (AllSlots[3].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[3]);
                }
                if (AllSlots[1].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[1]);
                }
            }

            // verificar peça 5
            if (AllSlots[5].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[6].Item1 == SlotTypes.Player
                    && AllSlots[7].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[7]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[4].Item1 == SlotTypes.Player
                   && AllSlots[3].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[3]);
                }
                if (AllSlots[4].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[4]);
                }
                if (AllSlots[0].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[0]);
                }
            }

            // verificar a peça 6
            if (AllSlots[6].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[5].Item1 == SlotTypes.Player
                    && AllSlots[0].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[0]);
                }
                if (AllSlots[5].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[5]);
                }
                if (AllSlots[4].Item1 == SlotTypes.Player
                   && AllSlots[1].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[1]);
                }

                if (AllSlots[4].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[4]);
                }

                if (AllSlots[3].Item1 == SlotTypes.Player
                   && AllSlots[2].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[2]);
                }

                if (AllSlots[3].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[3]);
                }

                if (AllSlots[7].Item1 == SlotTypes.Player
                   && AllSlots[12].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[12]);
                }

                if (AllSlots[7].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[7]);
                }

                if (AllSlots[8].Item1 == SlotTypes.Player
                   && AllSlots[11].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[11]);
                }

                if (AllSlots[8].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[8]);
                }

                if (AllSlots[9].Item1 == SlotTypes.Player
                   && AllSlots[10].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[10]);
                }

                if (AllSlots[9].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[9]);
                }
            }

            // verificar a peça 7
            if (AllSlots[7].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[12].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[12]);
                }
                if (AllSlots[8].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[8]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[6].Item1 == SlotTypes.Player
                    && AllSlots[5].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[5]);
                }
                if (AllSlots[8].Item1 == SlotTypes.Player
                   && AllSlots[9].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[9]);
                }
            }

            // verificar a peça 8
            if (AllSlots[8].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[9].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[9]);
                }
                if (AllSlots[11].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[11]);
                }
                if (AllSlots[7].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[7]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[6].Item1 == SlotTypes.Player
                   && AllSlots[4].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[4]);
                }
            }

            // verificar a peça 9
            if (AllSlots[9].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[8].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[8]);
                }
                if (AllSlots[10].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[10]);
                }
                if (AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
                if (AllSlots[8].Item1 == SlotTypes.Player
                   && AllSlots[7].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[7]);
                }
                if (AllSlots[6].Item1 == SlotTypes.Player
                 && AllSlots[3].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[3]);
                }
            }

            // verificar a peça 10
            if (AllSlots[10].Item1 == SlotTypes.AI)
            {
                // guardar as slots legais
                if (AllSlots[9].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[9]);
                }
                if (AllSlots[11].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[11]);
                }
                if (AllSlots[11].Item1 == SlotTypes.Player
                   && AllSlots[12].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[12]);
                }
                if (AllSlots[9].Item1 == SlotTypes.Player
                 && AllSlots[6].Item1 == SlotTypes.None)
                {
                    PlayerLegalPlays.Add(AllSlots[6]);
                }
            }

            // verificar a peça 11
                if (AllSlots[11].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
            }

            // verificar a peça 12
                if (AllSlots[12].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[9]);
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[11]);
                    }
                    if (AllSlots[7].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[6]);
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Player
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(AllSlots[10]);
                    }
            }
        }

        public GameState()
        {
            board = new Board();
            aiTurn = new AITurn();
            PlayerLegalPlays = new List<Tuple<SlotTypes, SlotColors>>();
            AILegalPlays = new List<Tuple<SlotTypes, SlotColors>>();
        }
    }
}
