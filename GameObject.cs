using System;

namespace Common
{
    /// <summary>
    /// Classe mãe de GameObject.
    /// </summary>
    public abstract class GameObject
    {
        public abstract void Start();
        public abstract void Update();
        public abstract void Render();
    }
}
