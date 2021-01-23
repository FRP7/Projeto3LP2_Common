using System;
using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Class where the GameData is stored.
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Gets and sets the player's color.
        /// </summary>
        public SlotColors PlayerType { get; set; }

        /// <summary>
        /// Gets and sets all the slots in the board (whether are occupied by 
        /// the player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> AllSlots { get; set; }

        /// <summary>
        /// List of all current possible plays. 
        /// </summary>
        public List<Tuple<int, SlotTypes, SlotColors, bool>> PlayerLegalPlays {
            get;
            set; 
        }

        /// <summary>
        /// Initialize the properties.
        /// </summary>
        public GameData()
        {
            AllSlots = new List<Tuple<SlotTypes, SlotColors>>();
            PlayerLegalPlays = new List<Tuple<int, SlotTypes,
                SlotColors, bool>>();
        }
    }
}
