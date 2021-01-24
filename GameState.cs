using System;
using System.Collections.Generic;
namespace Common
{
    /// <summary>
    /// The class where the game logic is worked.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Access the SetBoard class.
        /// </summary>
        public SetBoard board;

        // Cheks whether the piece was eaten.
        private bool isEaten;

        /// <summary>
        /// Gets and sets the player's color.
        /// </summary>
        public SlotColors PlayerType
        {
            get => board.PlayerType;
            set => board.PlayerType = value;
        }


        /// <summary>
        /// Gets and sets all the pieces in the game (whether are occupied by
        /// the player or not.
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> AllSlots
        {
            get => ServiceLocator.GetService<GameData>().AllSlots;
            set => ServiceLocator.GetService<GameData>().AllSlots = value;
        }

        /// <summary>
        /// List of all current possible plays for the player.
        /// </summary>
        public List<Tuple<int, SlotTypes, SlotColors, bool>> PlayerLegalPlays { get; set; }

        /// <summary>
        /// Gets and sets whether the player is the first to play.
        /// </summary>
        public bool IsPlayerFirst { get; set; }

        /// <summary>
        /// Gets and sets whether the player has won.
        /// </summary>
        public bool HasPlayerWon { get; set; }

        /// <summary>
        /// Gets and sets whether the opponent has won.
        /// </summary>
        public bool HasOpponentWon { get; set; }

        /// <summary>
        /// Delegate of the game loop.
        /// </summary>
        public delegate void GameLoop();

        // Access the GameLoop delegate.
        private GameLoop gameLoop;

        /// <summary>
        /// Method to be called in the first frame of the game (like Unity).
        /// </summary>
        public void Start()
        {
            // Set the board.
            board.Start();

            // Check who starts first.
            if (WhoStartsFirst())
            {
                IsPlayerFirst = true;
            }
            else
            {
                IsPlayerFirst = false;
            }
        }

        /// <summary>
        /// Check who starts first.
        /// </summary>
        /// <returns> Returns true whether the player is the first to play. 
        /// </returns>
        private bool WhoStartsFirst()
        {
            Random random = new Random();

            if (random.Next(0, 2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// List all the current possible plays.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <returns></returns>
        public bool CheckPlayerLegalPlays(int piece)
        {
            bool isLegal = true;

            if (piece == 0)
            {
                if (AllSlots[0].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[5].Item1 == SlotTypes.Opponent
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1,
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1,
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.Opponent
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 1)
            {
                if (AllSlots[1].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[4].Item1 == SlotTypes.Opponent
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[6].Item1,
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, false));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 2)
            {
                if (AllSlots[2].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[1].Item1 == SlotTypes.Opponent
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, true));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.Opponent &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 3)
            {
                if (AllSlots[3].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                        && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, true));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Opponent &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 4)
            {
                if (AllSlots[4].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                        && AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 5)
            {
                if (AllSlots[5].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                        && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Opponent
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 6)
            {
                if (AllSlots[6].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[5].Item1 == SlotTypes.Opponent
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Opponent
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, true));
                    }

                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.Opponent
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, true));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, false));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.Opponent
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(12, AllSlots[12].Item1, 
                            AllSlots[12].Item2, true));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, false));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.Opponent
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[11].Item2, true));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, false));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.Opponent
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1, 
                            AllSlots[10].Item2, true));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 7)
            {
                if (AllSlots[7].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(12, AllSlots[12].Item1, 
                            AllSlots[12].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, true));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Opponent
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 8)
            {
                if (AllSlots[8].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1,
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1,
                            AllSlots[4].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 9)
            {
                if (AllSlots[9].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1,
                            AllSlots[8].Item2, false));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1, 
                            AllSlots[10].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Opponent
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(7, AllSlots[7].Item1,
                            AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Opponent
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(3, AllSlots[3].Item1,
                            AllSlots[3].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 10)
            {
                if (AllSlots[10].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(9, AllSlots[9].Item1,
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Opponent
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(12, AllSlots[12].Item1, 
                            AllSlots[12].Item2, true));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.Opponent
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 11)
            {
                if (AllSlots[11].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(9, AllSlots[10].Item1, 
                            AllSlots[10].Item2, false));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[12].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(11, AllSlots[8].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Opponent
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 12)
            {
                if (AllSlots[12].Item1 == SlotTypes.Player)
                {
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.Opponent
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Opponent
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1,
                            AllSlots[10].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            // Update the legal plays list in the GameData.
            ServiceLocator.GetService<GameData>().PlayerLegalPlays = PlayerLegalPlays;

            return isLegal;
        }

        /// <summary>
        /// Checks whether the chosen play is legal.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <param name="slot"> Chose slot.</param>
        /// <returns> Returns true whether is legal.</returns>
        public bool CheckIfLegal(int piece, int slot)
        {
            bool isTrue = false;
            isEaten = false;

            foreach (Tuple<int, SlotTypes, SlotColors, bool> item in PlayerLegalPlays)
            {
                if (slot == item.Item1)
                {
                    isTrue = true;
                    if (item.Item4)
                    {
                        isEaten = true;
                    }
                }
            }
            return isTrue;
        }

        /// <summary>
        /// Play the chosen play.
        /// </summary>
        /// <param name="piece"> The chosen piece.</param>
        /// <param name="slot"> The chosen slot.</param>
        /// <param name="isPlayerWhite"> Check whether the player is white.
        /// </param>
        public void PlayerPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.White);
            }
            else if (!isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.Black);
            }

            if (isEaten)
            {
                EatPiece(piece, slot);
            }

            AllSlots[piece] = Tuple.Create(SlotTypes.None, SlotColors.Grey);

            PlayerLegalPlays.Clear();
        }

        /// <summary>
        /// List all current possible plays.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <returns> Returns true whether is legal.</returns>
        public bool CheckOpponentLegalPlays(int piece)
        {
            bool isLegal = true;

            if (piece == 0)
            {
                if (AllSlots[0].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[5].Item1 == SlotTypes.Player
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.Player
                        && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, true));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 1)
            {
                if (AllSlots[1].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[4].Item1 == SlotTypes.Player
                        && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, false));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 2)
            {
                if (AllSlots[2].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[1].Item1 == SlotTypes.Player
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, true));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.Player &&
                        AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 3)
            {
                if (AllSlots[3].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, true));
                    }
                    if (AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player &&
                        AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 4)
            {
                if (AllSlots[4].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1,
                            AllSlots[8].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1,
                            AllSlots[3].Item2, false));
                    }
                    if (AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1,
                            AllSlots[1].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 5)
            {
                if (AllSlots[5].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player
                       && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, true));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }
                    if (AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 6)
            {
                if (AllSlots[6].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[5].Item1 == SlotTypes.Player
                        && AllSlots[0].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(0, AllSlots[0].Item1, 
                            AllSlots[0].Item2, true));
                    }
                    if (AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, false));
                    }
                    if (AllSlots[4].Item1 == SlotTypes.Player
                       && AllSlots[1].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(1, AllSlots[1].Item1, 
                            AllSlots[1].Item2, true));
                    }

                    if (AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, false));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.Player
                       && AllSlots[2].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(2, AllSlots[2].Item1, 
                            AllSlots[2].Item2, true));
                    }

                    if (AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1,
                            AllSlots[3].Item2, false));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.Player
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(12, AllSlots[12].Item1, 
                            AllSlots[12].Item2, true));
                    }

                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1,
                            AllSlots[7].Item2, false));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[11].Item2, true));
                    }

                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, false));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.Player
                       && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1, 
                            AllSlots[10].Item2, true));
                    }

                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 7)
            {
                if (AllSlots[7].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(12, AllSlots[12].Item1, 
                            AllSlots[12].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1,
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                        && AllSlots[5].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(5, AllSlots[5].Item1, 
                            AllSlots[5].Item2, true));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1,
                            AllSlots[9].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 8)
            {
                if (AllSlots[8].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1,
                            AllSlots[1].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                       && AllSlots[4].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(4, AllSlots[4].Item1, 
                            AllSlots[4].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 9)
            {
                if (AllSlots[9].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[8].Item1, 
                            AllSlots[8].Item2, false));
                    }
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1, 
                            AllSlots[10].Item2, false));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[7].Item1, 
                            AllSlots[7].Item2, true));
                    }
                    if (AllSlots[6].Item1 == SlotTypes.Player
                     && AllSlots[3].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(3, AllSlots[3].Item1, 
                            AllSlots[3].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 10)
            {
                if (AllSlots[10].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[9].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1,
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1,
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Player
                       && AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes,
                            SlotColors, bool>(12, AllSlots[12].Item1,
                            AllSlots[12].Item2, true));
                    }
                    if (AllSlots[9].Item1 == SlotTypes.Player
                     && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 11)
            {
                if (AllSlots[11].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[10].Item1, 
                            AllSlots[10].Item2, false));
                    }
                    if (AllSlots[12].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(12, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(8, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[8].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                }
                else
                {
                    isLegal = false;
                }
            }

            if (piece == 12)
            {
                if (AllSlots[12].Item1 == SlotTypes.Opponent)
                {
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(9, AllSlots[9].Item1, 
                            AllSlots[9].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(7, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    if (AllSlots[7].Item1 == SlotTypes.Player
                       && AllSlots[6].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(6, AllSlots[6].Item1, 
                            AllSlots[6].Item2, true));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.Player
                     && AllSlots[10].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(10, AllSlots[10].Item1, 
                            AllSlots[10].Item2, true));
                    }
                    if (AllSlots[11].Item1 == SlotTypes.None)
                    {
                        PlayerLegalPlays.Add(new Tuple<int, SlotTypes, 
                            SlotColors, bool>(11, AllSlots[11].Item1, 
                            AllSlots[11].Item2, false));
                    }
                    isLegal = true;
                }
                else
                {
                    isLegal = false;
                }
            }

            // Update all the legal plays in GameData class.
            ServiceLocator.GetService<GameData>().PlayerLegalPlays = PlayerLegalPlays;

            return isLegal;
        }

        /// <summary>
        /// Play the chosen piece.
        /// </summary>
        /// <param name="piece"> The chosen piece.</param>
        /// <param name="slot"> The chosen slot.</param>
        /// <param name="isPlayerWhite"> Check whether the player is white.
        /// </param>
        public void OpponentPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Opponent,
                    SlotColors.White);
            }
            else if (!isPlayerWhite)
            {
                AllSlots[slot] = Tuple.Create(SlotTypes.Opponent,
                    SlotColors.Black);
            }
            if (isEaten)
            {
                EatPiece(piece, slot);
            }

            AllSlots[piece] = Tuple.Create(SlotTypes.None, SlotColors.Grey);

            PlayerLegalPlays.Clear();
        }

        /// <summary>
        /// Eat the piece.
        /// </summary>
        /// <param name="piece"> The chosen piece.</param>
        /// <param name="slot"> The chosen slot.</param>
        private void EatPiece(int piece, int slot)
        {
            if (piece == 0 && slot == 6)
            {
                AllSlots[5] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            if (piece == 0 && slot == 2)
            {
                AllSlots[1] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 1 && slot == 6)
            {
                AllSlots[4] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 2 && slot == 0)
            {
                AllSlots[1] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 2 && slot == 6)
            {
                AllSlots[3] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 3 && slot == 9)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 3 && slot == 5)
            {
                AllSlots[4] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 4 && slot == 8)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 5 && slot == 7)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 5 && slot == 3)
            {
                AllSlots[4] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 0)
            {
                AllSlots[5] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 1)
            {
                AllSlots[4] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 2)
            {
                AllSlots[3] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 10)
            {
                AllSlots[9] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 12)
            {
                AllSlots[7] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 11)
            {
                AllSlots[8] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 6 && slot == 10)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 7 && slot == 5)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 7 && slot == 9)
            {
                AllSlots[8] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 8 && slot == 4)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 9 && slot == 7)
            {
                AllSlots[8] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 9 && slot == 3)
            {
                AllSlots[6] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 10 && slot == 12)
            {
                AllSlots[11] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 10 && slot == 6)
            {
                AllSlots[9] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 11 && slot == 6)
            {
                AllSlots[8] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 12 && slot == 6)
            {
                AllSlots[7] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
            else if (piece == 12 && slot == 10)
            {
                AllSlots[11] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
            }
        }

        /// <summary>
        /// Check if there's any victory.
        /// </summary>
        /// <returns> Returns Player if the player won or Opponent if the 
        /// opponent won or None if there's no victory yet.</returns>
        public Victory CheckWin()
        {
            int countPlayer = 0;
            int countOpponent = 0;

            foreach (Tuple<SlotTypes, SlotColors> items in AllSlots)
            {
                if (items.Item1 == SlotTypes.Player)
                {
                    countPlayer++;

                }
                else if (items.Item1 == SlotTypes.Opponent)
                {
                    countOpponent++;
                }
            }

            if (countPlayer == 0)
            {
                return Victory.Opponent;
            }

            else if (countOpponent == 0)
            {
                return Victory.Player;

            }
            else
            {

                return Victory.None;
            }
        }

        /// <summary>
        /// Initialize the variables and properties.
        /// </summary>
        public GameState()
        {
            board = new SetBoard();
            PlayerLegalPlays = new List<Tuple<int, SlotTypes, 
                SlotColors, bool>>();
        }
    }
}
