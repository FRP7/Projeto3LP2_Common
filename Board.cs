using System;
using UnityEngine; // testar

namespace Common
{
    public class Board
    {
        public SlotTypes PlayerType { get; set; }

        private SlotTypes[] getSlotTypes;

        public SlotTypes[] GetSlotTypes
        {
            get => getSlotTypes;
            set => getSlotTypes = value;
        }

        public void Start()
        {
            SetColor();
        }

        public void Update()
        {
            Debug.Log("Tabuleiro atualizado.");
        }

        private void SetColor()
        {
            getSlotTypes = new SlotTypes[13];

            if (PlayerType == SlotTypes.Black)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    getSlotTypes[i] = SlotTypes.Black;
                }

                // Colocar as peças da ai .
                for (int i = 6; i < 12; i++)
                {
                    getSlotTypes[i] = SlotTypes.White;
                }

            }
            else if (PlayerType == SlotTypes.White)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    getSlotTypes[i] = SlotTypes.White;
                }

                // Colocar as peças da ai .
                for (int i = 6; i < 12; i++)
                {
                    getSlotTypes[i] = SlotTypes.Black;
                }
            }

            // Colocar as peças vazias cizentas.
            getSlotTypes[12] = SlotTypes.Grey;
        }

        public Board()
        {
        }
    }
}
