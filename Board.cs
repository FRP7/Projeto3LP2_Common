using System;
using System.Collections.Generic;
using UnityEngine; // testar

namespace Common
{
    public class Board
    {
        public SlotTypes PlayerType { get; set; }

        public ICollection<SlotTypes> PlayerPieces { get; set; }

        public ICollection<SlotTypes> AIPieces { get; set; }

        public ICollection<SlotTypes> NoPieces { get; set; }

        public void Start()
        {
            SetColor();

            // testar
            int white = 0;
            int black = 0;
            int grey = 0;

            foreach(SlotTypes item in PlayerPieces)
            {
                if(PlayerType == SlotTypes.Black)
                {
                    black++;
                }
                else if (PlayerType == SlotTypes.White)
                {
                    white++;
                }
            }

            foreach (SlotTypes item in AIPieces)
            {
                if (PlayerType == SlotTypes.Black)
                {
                    white++;
                }
                else if (PlayerType == SlotTypes.White)
                {
                    black++;
                }
            }

            foreach (SlotTypes item in NoPieces)
            {
                grey++;
            }

                Debug.Log("Número de peças brancas: " + white);
            Debug.Log("Número de peças pretas: " + black);
            Debug.Log("Número de peças cinzentas: " + grey);
        }

        public void Update()
        {
            Debug.Log("Tabuleiro atualizado.");
        }

        public void UpdateColors()
        {

        }

        private void SetColor()
        {

            if (PlayerType == SlotTypes.Black)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    PlayerPieces.Add(SlotTypes.Black);
                }

                // Colocar as peças da ai .
                for (int i = 6; i < 12; i++)
                {
                    AIPieces.Add(SlotTypes.White);
                }

            }
            else if (PlayerType == SlotTypes.White)
            {
                // Colocar as peças do jogador .
                for (int i = 0; i < 6; i++)
                {
                    PlayerPieces.Add(SlotTypes.White);
                }

                // Colocar as peças da ai .
                for (int i = 6; i < 12; i++)
                {
                    AIPieces.Add(SlotTypes.Black);
                }
            }

            // Colocar as peças vazias cizentas.
            NoPieces.Add(SlotTypes.Grey);
        }

        public Board()
        {
            PlayerPieces = new List<SlotTypes>();
            AIPieces = new List<SlotTypes>();
            NoPieces = new List<SlotTypes>();
        }
    }
}
