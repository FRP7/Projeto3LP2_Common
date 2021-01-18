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

        private bool isEaten;

        // Cor do jogador.
        public SlotColors PlayerType
        {
            get => board.PlayerType;
            set => board.PlayerType = value;
        }


        // Todas as peças.
        public List<Tuple<SlotTypes, SlotColors>> AllSlots
        {
            //get => board.AllSlots;
            get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
            //set => board.AllSlots = value;
            set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }

        // Coleção de jogadas possíveis para o jogador.
        // o bool é se é pa comer peça
        public List<Tuple<int, SlotTypes, SlotColors, bool>> PlayerLegalPlays { get; set; }

        // Coleção de jogadas possíveis para a AI. int = peça, int = slot
        public List<Tuple<int, int, SlotTypes, SlotColors, bool>> AILegalPlays { get; set; }

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
        }

        public bool CheckPlayerLegalPlays(int piece)
        {
            Debug.Log("Verificar jogadas possíveis do jogador");

            bool isLegal = true;

            // verificar peça 0
            if (piece == 0)
            {
                if (AllSlots[0].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.AI
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.AI
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
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
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(4, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(0, AllSlots[0].Item1, AllSlots[0].Item2, false));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
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
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(0, AllSlots[0].Item1, AllSlots[0].Item2, true));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.AI &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 2 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, true));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(5, AllSlots[5].Item1, AllSlots[5].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 3 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(8, AllSlots[8].Item1, AllSlots[8].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 4 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(7, AllSlots[7].Item1, AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(3, AllSlots[3].Item1, AllSlots[3].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        // PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(0, AllSlots[0].Item1, AllSlots[0].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 5 não é do jogador");
                }
            }

            // verificar a peça 6
            if (piece == 6)
            {
                //Debug.Log("Tamanho da lista: " + AllSlots.Count);
                //Debug.Log($"Conteúdo da slot: {AllSlots[piece].Item1.ToString()}");
                if (AllSlots[6].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.AI
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(0, AllSlots[0].Item1, AllSlots[0].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(1, AllSlots[1].Item1, AllSlots[1].Item2, true));
                    }

                    // o bug deve estar aqui
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.AI
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(2, AllSlots[2].Item1, AllSlots[2].Item2, true));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(12, AllSlots[12].Item1, AllSlots[12].Item2, true));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(7, AllSlots[7].Item1, AllSlots[7].Item2, false));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[11].Item2, true));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.AI
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(10, AllSlots[10].Item1, AllSlots[10].Item2, true));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 6 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(12, AllSlots[12].Item1, AllSlots[12].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(5, AllSlots[5].Item1, AllSlots[5].Item2, true));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, true));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 7 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[1].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(7, AllSlots[7].Item1, AllSlots[7].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(4, AllSlots[4].Item1, AllSlots[4].Item2, true));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 8 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(10, AllSlots[10].Item1, AllSlots[10].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(7, AllSlots[7].Item1, AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(3, AllSlots[3].Item1, AllSlots[3].Item2, true));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 9 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(12, AllSlots[12].Item1, AllSlots[12].Item2, true));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.AI
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 10 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[10].Item1, AllSlots[10].Item2, false));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 11 não é do jogador");
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors, bool>(10, AllSlots[10].Item1, AllSlots[10].Item2, true));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false;
                    Debug.Log("A peça 12 não é do jogador");
                }
            }
            else
            {
                Debug.Log("Nenhuma das jogadas é valida");
            }

            Debug.Log("Jogada legal");

            // testar
            /*foreach(var item in PlayerLegalPlays)
            {
                Debug.Log($"Type: {item.Item1}. Color: {item.Item2}");
            }*/

            // registar as jogadas.
            ServiceLocator.Register<List<Tuple<int, SlotTypes, SlotColors, bool>>>(PlayerLegalPlays);

            return isLegal;
        }

        public bool CheckIfLegal(int piece, int slot)
        {
            bool isTrue = false;
            isEaten = false;

            foreach(Tuple<int, SlotTypes, SlotColors, bool> item in PlayerLegalPlays)
            {
                // comparar a piece com a slot?
                if(slot == item.Item1)
                {
                    isTrue = true;
                    if(item.Item4)
                    {
                        isEaten = true;
                    }
                    Debug.Log("A jogada é legal");
                }
                else
                {
                    Debug.Log("A jogada é ilegal");
                }            
            }
            return isTrue;
        }

        public void PlayerPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.White);
            }
            else if (!isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.Black);
                Debug.Log("Atualizar peças.");
            }
            // caso coma alguma peça (not sure se funciona ainda)
            if(isEaten)
            {
                AllSlots[piece + 1] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            // acontece independente
            AllSlots[piece] = Tuple.Create(SlotTypes.None, SlotColors.Grey);

            PlayerLegalPlays.Clear();
        }

        private void CheckAILegalPlays()
        {
            Debug.Log("Verificar jogadas possíveis da AI");
            int piece = 0;

            // verificar peça 0
            if (piece == 0)
            {
                if (AllSlots[0].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.Player
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(0, 6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(0, 5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.Player
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(0, 2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(0, 1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }

                }
            }
            // verificar peça 1
            if (piece == 1)
            {
                if (AllSlots[1].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[4].Item1 == SlotTypes.Player
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(1, 6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(1, 4, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(1, 0, AllSlots[0].Item1, AllSlots[0].Item2, false));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(1, 2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                }
            }

            // verificar peça 2
            if (piece == 2)
            {
                if (AllSlots[2].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[1].Item1 == SlotTypes.Player
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(2, 0, AllSlots[0].Item1, AllSlots[0].Item2, true));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(2, 1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.Player &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(2, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(2, 3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }
                }
            }


            // verificar peça 3
            if (piece == 3)
            {
                if (AllSlots[3].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(3, 9, AllSlots[9].Item1, AllSlots[9].Item2, true));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(3, 2, AllSlots[2].Item1, AllSlots[2].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(3, 5, AllSlots[5].Item1, AllSlots[5].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(3, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(3, 4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }
                }
            }


            // verificar peça 4
            if (piece == 4)
            {
                if (AllSlots[4].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(4, 8, AllSlots[8].Item1, AllSlots[8].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(4, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(4, 5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(4, 3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(4, 1, AllSlots[1].Item1, AllSlots[1].Item2, false));
                    }
                }
            }


            // verificar peça 5
            if (piece == 5)
            {
                if (AllSlots[5].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(5, 7, AllSlots[7].Item1, AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(5, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(5, 3, AllSlots[3].Item1, AllSlots[3].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        // PlayerLegalPlays.Add(AllSlots[4]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(5, 4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(5, 0, AllSlots[0].Item1, AllSlots[0].Item2, false));
                    }
                }
            }


            // verificar a peça 6
            if (piece == 6)
            {
                if (AllSlots[6].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.Player
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 0, AllSlots[0].Item1, AllSlots[0].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 5, AllSlots[5].Item1, AllSlots[5].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 1, AllSlots[1].Item1, AllSlots[1].Item2, true));
                    }

                    // o bug deve estar aqui
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 4, AllSlots[4].Item1, AllSlots[4].Item2, false));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.Player
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 2, AllSlots[2].Item1, AllSlots[2].Item2, true));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 3, AllSlots[3].Item1, AllSlots[3].Item2, false));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.Player
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 12, AllSlots[12].Item1, AllSlots[12].Item2, true));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 7, AllSlots[7].Item1, AllSlots[7].Item2, false));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 11, AllSlots[11].Item1, AllSlots[11].Item2, true));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.Player
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 10, AllSlots[10].Item1, AllSlots[10].Item2, true));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(6, 9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                }
            }


            // verificar a peça 7
            if (piece == 7)
            {
                if (AllSlots[7].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(7, 12, AllSlots[12].Item1, AllSlots[12].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(7, 8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(7, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(7, 5, AllSlots[5].Item1, AllSlots[5].Item2, true));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(7, 9, AllSlots[9].Item1, AllSlots[9].Item2, true));
                    }
                }
            }


            // verificar a peça 8
            if (piece == 8)
            {
                if (AllSlots[8].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(8, 9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(8, 11, AllSlots[11].Item1, AllSlots[1].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(8, 7, AllSlots[7].Item1, AllSlots[7].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(8, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(8, 4, AllSlots[4].Item1, AllSlots[4].Item2, true));
                    }
                }
            }


            // verificar a peça 9
            if (piece == 9)
            {
                if (AllSlots[9].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(9, 8, AllSlots[8].Item1, AllSlots[8].Item2, false));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(9, 10, AllSlots[10].Item1, AllSlots[10].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(9, 6, AllSlots[6].Item1, AllSlots[6].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(9, 7, AllSlots[7].Item1, AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(9, 3, AllSlots[3].Item1, AllSlots[3].Item2, true));
                    }
                }
            }


            // verificar a peça 10
            if (piece == 10)
            {
                if (AllSlots[10].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(10, 9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(10, 11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Player
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(10, 12, AllSlots[12].Item1, AllSlots[12].Item2, true));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.Player
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(10, 6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                }
            }


            // verificar a peça 11
            if (piece == 11)
            {
                if (AllSlots[11].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(11, 9, AllSlots[10].Item1, AllSlots[10].Item2, false));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(11, 11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(11, 11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(11, 6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                }
            }


            // verificar a peça 12
            if (piece == 12)
            {
                if (AllSlots[12].Item1 == SlotTypes.AI)
                {
                    // guardar as slots legais
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(12, 9, AllSlots[9].Item1, AllSlots[9].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(12, 11, AllSlots[11].Item1, AllSlots[11].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(12, 6, AllSlots[6].Item1, AllSlots[6].Item2, true));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Player
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        AILegalPlays.Add(new Tuple<int, int, SlotTypes, SlotColors, bool>(12, 10, AllSlots[10].Item1, AllSlots[10].Item2, true));
                    }
                }
            }
            // registar as jogadas.
            ServiceLocator.Register<List<Tuple<int, int, SlotTypes, SlotColors, bool>>>(AILegalPlays);
        }

        public GameState()
        {
            board = new Board();
            aiTurn = new AITurn();
            PlayerLegalPlays = new List<Tuple<int, SlotTypes, SlotColors, bool>>();
            AILegalPlays = new List<Tuple<int, int, SlotTypes, SlotColors, bool>>();
        }
    }
}
