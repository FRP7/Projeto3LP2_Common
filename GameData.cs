using System;
using System.Collections.Generic;

namespace Common
{
    public class GameData
    {
        public SlotColors PlayerType { get; set; }

        public List<Tuple<SlotTypes, SlotColors>> AllSlots { get; set; }

        // Coleção de jogadas possíveis para o jogador.
        // o bool é se é pa comer peça
        public List<Tuple<int, SlotTypes, SlotColors, bool>> PlayerLegalPlays { get; set; }

        // Coleção de jogadas possíveis para a AI. int = peça, int = slot
        public List<Tuple<int, int, SlotTypes, SlotColors, bool>> AILegalPlays { get; set; }

        public GameData()
        {
            AllSlots = new List<Tuple<SlotTypes, SlotColors>>();
            PlayerLegalPlays = new List<Tuple<int, SlotTypes, SlotColors, bool>>();
            AILegalPlays = new List<Tuple<int, int, SlotTypes, SlotColors, bool>>();
        }
    }
}
