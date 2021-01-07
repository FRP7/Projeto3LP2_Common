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

        /// <summary>
        /// Indicar qual a cor que o jogador escolheu.
        /// </summary>
        public Colors playerColor { get; set; }

        public void Start()
        {
            IsGameOver = false;

            // Registar a cor que o jogador escolheu.
            ServiceLocator.Register<Colors>(playerColor);
        }

        public void Update()
        {
        }

        public void Render()
        {
          
        }

        public GameState()
        {
           
        }
    }
}
