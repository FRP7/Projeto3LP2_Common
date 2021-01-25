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
        /// Gets or sets the player's color.
        /// </summary>
        public SlotColors PlayerType { get; set; }

        /// <summary>
        /// Gets or sets all the slots in the board (whether are occupied by
        /// the player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> AllSlots { get; set; }

        /// <summary>
        /// Gets or sets of all current possible plays.
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
