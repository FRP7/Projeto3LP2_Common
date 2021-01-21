using System;
using System.Collections.Generic;

namespace Common
{
    public class SetBoard
    {
        public SlotColors PlayerType { get; set; }

        public List<Tuple<SlotTypes, SlotColors>> AllSlots { get; set; }

        public void Start()
        {
            SetColor();
        }

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

            // registar
            ServiceLocator.Register<List<Tuple<SlotTypes, SlotColors>>>(AllSlots);
        }

        public SetBoard()
        {
            AllSlots = new List<Tuple<SlotTypes, SlotColors>>();
        }
    }
}
