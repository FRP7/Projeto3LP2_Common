using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Set the game board.
    /// </summary>
    public class SetBoard
    {
        /// <summary>
        /// Gets and sets the player's color.
        /// </summary>
        public SlotColors PlayerType { get; set; }

        /// <summary>
        /// Gets and sets the list of all slots in the board (whether are
        /// occupied by the player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> AllSlots { get; set; }

        /// <summary>
        /// Access the GameData class.
        /// </summary>
        private GameData gameData;

        /// <summary>
        /// To be called in the first frame of the game (like Unity).
        /// </summary>
        public void Start()
        {
            SetColor();
        }

        /// <summary>
        /// Set the colors in the board.
        /// </summary>
        private void SetColor()
        {

            if (PlayerType == SlotColors.Black)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.Player, SlotColors.Black));
                }

                // Colocar as peças vazias cizentas.
                AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.None, SlotColors.Grey));

                // Colocar as peças da ai .
                for (int i = 7; i < 13; i++)
                {
                    AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.Opponent, SlotColors.White));
                }

            }
            else if (PlayerType == SlotColors.White)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.Player, SlotColors.White));
                }

                // Colocar as peças vazias cizentas.
                AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.None, SlotColors.Grey));

                // Colocar as peças da ai .
                for (int i = 7; i < 13; i++)
                {
                    AllSlots.Add(new Tuple<SlotTypes, SlotColors>(SlotTypes.Opponent, SlotColors.Black));
                }
            }
         
            //ServiceLocator.Register<List<Tuple<SlotTypes, SlotColors>>>(AllSlots);

            // Register the GameData slot.
            ServiceLocator.Register<GameData>(gameData);

            // Update the AllSlots list in the GameData class.
            ServiceLocator.GetService<GameData>().AllSlots = AllSlots;

            // Update the PlayerType variable in the GameData class.
            ServiceLocator.GetService<GameData>().PlayerType = PlayerType;
        }

        /// <summary>
        /// Initialize the variables and properties.
        /// </summary>
        public SetBoard()
        {
            AllSlots = new List<Tuple<SlotTypes, SlotColors>>();
            gameData = new GameData();
        }
    }
}
