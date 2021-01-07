using System;

namespace Common
{
    /// <summary>
    /// Classe onde a lógica do jogo acontece (update). 
    /// </summary>
    class GameState
    {
        /// <summary>
        /// Indicar se o jogo acabou.
        /// </summary>
        public bool IsGameOver { get; private set; }

        private Board board;

        public Slots[] GetSlots { get; }

        /// <summary>
        /// Indicar qual a cor que o jogador escolheu.
        /// </summary>
        public Colors PlayerColor { get; set; }

        public void Start()
        {
            IsGameOver = false;

            PlayerColor = Colors.White;

            // Registar a cor que o jogador escolheu.
            ServiceLocator.Register<Colors>(PlayerColor);

            board.Start();
        }

        public void Update()
        {
            board.Update();
            AITurn();
            board.Update();
        }

        private void AITurn()
        {
            AI ai = new AI();
            ai.AITurn();
            // mover as cenas
        }

        public GameState()
        {
            IsGameOver = false;
            board = new Board();
            GetSlots = board.GetSlots;
        }
    }
}
