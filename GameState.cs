﻿using System;
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
            //set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }

        // Coleção de jogadas possíveis para o jogador.
        public List<Tuple<int, SlotTypes, SlotColors>> PlayerLegalPlays { get; set; }

        // Coleção de jogadas possíveis para a AI.
        public List<Tuple<SlotTypes, SlotColors>> AILegalPlays { get; set; }

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

            // testar
            /*foreach(var item in AllSlots)
            {
                Debug.Log($"Type: {item.Item1}. Color: {item.Item2}");
            }*/

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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(0, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(0, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.AI
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(0, AllSlots[2].Item1, AllSlots[2].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(0, AllSlots[1].Item1, AllSlots[1].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(1, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(1, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(1, AllSlots[0].Item1, AllSlots[0].Item2));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(1, AllSlots[2].Item1, AllSlots[2].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(2, AllSlots[0].Item1, AllSlots[0].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(2, AllSlots[1].Item1, AllSlots[1].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.AI &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(2, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(2, AllSlots[3].Item1, AllSlots[3].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[2].Item1, AllSlots[2].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(3, AllSlots[4].Item1, AllSlots[4].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[8].Item1, AllSlots[8].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[3].Item1, AllSlots[3].Item2));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(4, AllSlots[1].Item1, AllSlots[1].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[3].Item1, AllSlots[3].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        // PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[4].Item1, AllSlots[4].Item2));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(5, AllSlots[0].Item1, AllSlots[0].Item2));
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
                if (AllSlots[6].Item1 == SlotTypes.Player)
                {
                    // guardar as slots legais
                    if (AllSlots[5].Item1 == SlotTypes.AI
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[0]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[0].Item1, AllSlots[0].Item2));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.AI
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[1]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[1].Item1, AllSlots[1].Item2));
                    }

                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[4].Item1, AllSlots[4].Item2));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.AI
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[2]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[2].Item1, AllSlots[2].Item2));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[3].Item1, AllSlots[3].Item2));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[12].Item1, AllSlots[12].Item2));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[7].Item1, AllSlots[7].Item2));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[11].Item1, AllSlots[11].Item2));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[8].Item1, AllSlots[8].Item2));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.AI
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[10].Item1, AllSlots[10].Item2));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(6, AllSlots[9].Item1, AllSlots[9].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[12].Item1, AllSlots[12].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[8]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[8].Item1, AllSlots[8].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[5]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[5].Item1, AllSlots[5].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[9]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(7, AllSlots[9].Item1, AllSlots[9].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[11].Item1, AllSlots[1].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[4]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(8, AllSlots[4].Item1, AllSlots[4].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[8].Item1, AllSlots[8].Item2));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[10].Item1, AllSlots[10].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[7]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[7].Item1, AllSlots[7].Item2));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.AI
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[3]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(9, AllSlots[3].Item1, AllSlots[3].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(10, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(10, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[12]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(10, AllSlots[12].Item1, AllSlots[12].Item2));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.AI
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(10, AllSlots[6].Item1, AllSlots[6].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(11, AllSlots[10].Item1, AllSlots[10].Item2));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(11, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(11, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(11, AllSlots[6].Item1, AllSlots[6].Item2));
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
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(12, AllSlots[9].Item1, AllSlots[9].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[11]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(12, AllSlots[11].Item1, AllSlots[11].Item2));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.AI
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[6]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(12, AllSlots[6].Item1, AllSlots[6].Item2));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.AI
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        //PlayerLegalPlays.Add(AllSlots[10]);
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, SlotColors>(12, AllSlots[10].Item1, AllSlots[10].Item2));
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
            AILegalPlays = new List<Tuple<SlotTypes, SlotColors>>();
        }
    }
}
