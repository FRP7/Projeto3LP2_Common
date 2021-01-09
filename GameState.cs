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
            //get => board.AllSlots;
            get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
            //set => board.AllSlots = value;
            set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }

        // Coleção de jogadas possíveis para o jogador.
        public List<Tuple<int, SlotTypes, SlotColors>> PlayerLegalPlays { get; private set; }

        // Coleção de jogadas possíveis para a AI.
        public List<Tuple<float, SlotTypes, SlotColors>> AILegalPlays { get; private set; }

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
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(0, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(1, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.AI
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(2, AllSlots[2].Item1, AllSlots[2].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[1].Item1, AllSlots[1].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[4].Item1, AllSlots[4].Item2));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[0].Item1, AllSlots[0].Item2));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[2].Item1, AllSlots[2].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[2].Item1, AllSlots[2].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[1].Item1, AllSlots[1].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.AI &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(10, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(11, AllSlots[3].Item1, AllSlots[3].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(12, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        // PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(13, AllSlots[2].Item1, AllSlots[2].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(14, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(15, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(16, AllSlots[4].Item1, AllSlots[4].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(17, AllSlots[8].Item1, AllSlots[8].Item2));
                        //PlayerLegalPlays.Add(AllSlots[8]);
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(18, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(19, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(20, AllSlots[3].Item1, AllSlots[3].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(21, AllSlots[1].Item1, AllSlots[1].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(22, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(23, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(24, AllSlots[3].Item1, AllSlots[3].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(25, AllSlots[4].Item1, AllSlots[4].Item2));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(26, AllSlots[0].Item1, AllSlots[0].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(27, AllSlots[0].Item1, AllSlots[0].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(28, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(29, AllSlots[1].Item1, AllSlots[1].Item2));
                    }

                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(30, AllSlots[4].Item1, AllSlots[4].Item2));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.AI
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(31, AllSlots[2].Item1, AllSlots[2].Item2));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(32, AllSlots[3].Item1, AllSlots[3].Item2));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(33, AllSlots[12].Item1, AllSlots[12].Item2));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(34, AllSlots[7].Item1, AllSlots[7].Item2));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(35, AllSlots[11].Item1, AllSlots[11].Item2));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(36, AllSlots[8].Item1, AllSlots[8].Item2));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.AI
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(37, AllSlots[10].Item1, AllSlots[10].Item2));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(38, AllSlots[9].Item1, AllSlots[9].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(39, AllSlots[12].Item1, AllSlots[12].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(40, AllSlots[8].Item1, AllSlots[8].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(41, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(42, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(43, AllSlots[9].Item1, AllSlots[9].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(44, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(45, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(46, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(47, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(48, AllSlots[4].Item1, AllSlots[4].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(49, AllSlots[8].Item1, AllSlots[8].Item2));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(50, AllSlots[10].Item1, AllSlots[10].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(51, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(52, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(53, AllSlots[3].Item1, AllSlots[3].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(53, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(54, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(55, AllSlots[12].Item1, AllSlots[12].Item2));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.AI
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(56, AllSlots[6].Item1, AllSlots[6].Item2));
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(57, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(58, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(59, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(60, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
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
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(61, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(62, AllSlots[10].Item1, AllSlots[10].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(63, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(64, AllSlots[10].Item1, AllSlots[10].Item2));
                    }
                    isLegal = true;
                }
                else // a peça não é do jogador
                {
                    isLegal = false; ;
                }
            }
            ServiceLocator.Register<List<Tuple<int, SlotTypes, SlotColors>>>(PlayerLegalPlays);
            return isLegal;
        }

        private void CheckAILegalPlays()
        {
            Debug.Log("Verificar jogadas possíveis da AI");
        }

        public GameState()
        {
            board = new Board();
            aiTurn = new AITurn();
            PlayerLegalPlays = new List<Tuple<int, SlotTypes, SlotColors>>();
            AILegalPlays = new List<Tuple<float, SlotTypes, SlotColors>>();
        }
    }
}
