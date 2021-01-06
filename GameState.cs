using System;

namespace Common
{
    /// <summary>
    /// Classe onde a lógica do jogo acontece (update). 
    /// </summary>
    class GameState
    {
        /// <summary>
        /// Array de GameObjects.
        /// </summary>
        public readonly GameObject[] gameObject;

        /// <summary>
        /// Indicar se o jogo acabou.
        /// </summary>
        public bool IsGameOver { get; private set; }

        public void Update()
        {
            gameObject[2].Update();
            gameObject[1].Update();
            gameObject[0].Update();
        }

        public GameState()
        {
            IsGameOver = false;
            gameObject[0] = new BlackPiece();
            gameObject[1] = new WhitePiece();
            gameObject[2] = new Board();
        }
    }
}
