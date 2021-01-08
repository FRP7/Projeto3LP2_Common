using System;

namespace Common
{
    public class GameState
    {
        private SlotTypes playerType;
        public SlotTypes GetPlayerType => playerType;

        private SlotTypes[] getSlotTypes;
        public SlotTypes[] GetSlotTypes => getSlotTypes;

        public void Start()
        {
            SetColor();
        }

        public void Update()
        {

        }

        private void SetColor()
        {
            // Escolher a cor do jogador.
            playerType = SlotTypes.Black;
            getSlotTypes = new SlotTypes[13];
            
            // Colocar as peças do jogador pretas.
            for(int i = 0; i < 6; i++)
            {
                getSlotTypes[i] = SlotTypes.Black;
            }

            // Colocar as peças da ai pretas.
            for (int i = 6; i < 11; i++)
            {
                getSlotTypes[i] = SlotTypes.White;
            }

            // Colocar as peças vazias cizentas.
            getSlotTypes[12] = SlotTypes.Grey;
        }
    }
}
