using System;
using UnityEngine; // testar
using System.Collections.Generic;
using Random = System.Random; // testar
using URand = UnityEngine.Random; // testar

namespace Common
{
    public class AITurn
    {
        // Todas as peças.
        public List<Tuple<int, int, SlotTypes, SlotColors, bool>> AILegalPlays
        {
            //get => board.AllSlots;
            get => ServiceLocator.GetService<List<Tuple<int, int, SlotTypes, SlotColors, bool>>>();
            //set => board.AllSlots = value;
            set => ServiceLocator.GetService<List<Tuple<int, int, SlotTypes, SlotColors, bool>>>();
        }

        public void AIPlay()
        {
            Debug.Log("AI joga.");
        }
    }
}
