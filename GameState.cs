using System;

namespace Common
{
    /// <summary>
    /// Classe onde a lógica do jogo acontece (update). 
    /// </summary>
    class GameState
    {
        public readonly GameObject[] blackPieces;

        public readonly GameObject[] whitePieces;

        public readonly GameObject board;

        /// <summary>
        /// Indicar se o jogo acabou.
        /// </summary>
        public bool IsGameOver { get; private set; }

        /// <summary>
        /// Indicar qual a cor que o jogador escolheu.
        /// </summary>
        public Colors playerColor { get; set; }

        public void Start()
        {
            IsGameOver = false;

            // Registar a cor que o jogador escolheu.
            ServiceLocator.Register<Colors>(playerColor);

            // Start das peças pretas.
            foreach(GameObject item in blackPieces)
            {
                item.Start();
            }

            // Start das peças brancas.
            foreach (GameObject item in whitePieces)
            {
                item.Start();
            }

            // Start do tabuleiro.
            board.Start();
        }

        public void Update()
        {
            // Pensar numa maneira de o jogador controlar as peças de cor x
            board.Update();
        }

        public void Render()
        {
            foreach (GameObject item in blackPieces)
            {
                item.Render();
            }

            foreach (GameObject item in whitePieces)
            {
                item.Render();
            }

            board.Render();
        }

        public GameState()
        {
            blackPieces = new GameObject[6];
            blackPieces[0] = new BlackPiece();
            blackPieces[1] = new BlackPiece();
            blackPieces[2] = new BlackPiece();
            blackPieces[3] = new BlackPiece();
            blackPieces[4] = new BlackPiece();
            blackPieces[5] = new BlackPiece();

            whitePieces = new GameObject[6];
            whitePieces[0] = new WhitePiece();
            whitePieces[1] = new WhitePiece();
            whitePieces[2] = new WhitePiece();
            whitePieces[3] = new WhitePiece();
            whitePieces[4] = new WhitePiece();
            whitePieces[5] = new WhitePiece();

            board = new Board();
        }
    }
}
