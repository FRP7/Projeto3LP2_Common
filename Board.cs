using System;

namespace Common
{
    /// <summary>
    /// Board GameObject.
    /// </summary>
    public class Board
    {
        public Slots[] GetSlots => slots;

        /// <summary>
        /// Se for 
        /// </summary>
        private Slots[] slots;

        public void Start()
        {
            SetPieces();
        }

        public void Update()
        {

        }

        private void SetPieces()
        {
            slots = new Slots[13];
            for(int i = 0; i < 5; i++)
            {
                slots[i] = Slots.Player;
            }
            for (int i = 6; i < 11; i++)
            {
                slots[i] = Slots.AI;
            }
            slots[12] = Slots.None;

            // Registar as peças.
            ServiceLocator.Register<Slots>(GetSlots);
        }
    }
}
