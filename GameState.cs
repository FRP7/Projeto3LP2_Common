using System;

namespace Common
{
    public class GameState
    {
        private Board board;

        public SlotTypes[] GetSlotTypes { get => board.GetSlotTypes; set => board.GetSlotTypes = value; }

        public void Start()
        {
            board.Start();
        }

        public void Update()
        {

        }

        public GameState()
        {
            board = new Board();
        }
    }
}
