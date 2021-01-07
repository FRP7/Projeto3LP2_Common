using System;
using System.Numerics;

namespace Common
{
    /// <summary>
    /// White piece gameobject.
    /// </summary>
    public class WhitePiece : GameObject
    {
        public Vector2 GetVector2 => getVector2;

        private Vector2 getVector2;

        private float cordX;
        private float cordY;

        public override void Start()
        {
            getVector2 = new Vector2(cordX, cordY);
        }

        public override void Update()
        {
            Play();
        }

        public override void Render()
        {

        }

        private void Play()
        {

        }
    }
}
