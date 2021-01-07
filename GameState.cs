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

        public void Start()
        {
            IsGameOver = false;
            foreach(GameObject item in gameObject)
            {
                item.Start();
            }
        }

        public void Update()
        {
            foreach (GameObject item in gameObject)
            {
                item.Update();
            }
        }

        public GameState()
        {
            gameObject = new GameObject[13];
            gameObject[0] = new BlackPiece();
            gameObject[1] = new BlackPiece();
            gameObject[2] = new BlackPiece();
            gameObject[3] = new BlackPiece();
            gameObject[4] = new BlackPiece();
            gameObject[5] = new BlackPiece();
            gameObject[6] = new WhitePiece();
            gameObject[7] = new WhitePiece();
            gameObject[8] = new WhitePiece();
            gameObject[9] = new WhitePiece();
            gameObject[10] = new WhitePiece();
            gameObject[11] = new WhitePiece();
            gameObject[12] = new Board();
        }
    }
}
