using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WWC.Def;

namespace WWC.GameObject
{
    //突撃AI
    class TotugekiAI:AI
    {
        private Vector2 velocity;
        private float speed = 0.5f;

        public TotugekiAI()
        {
            velocity = new Vector2(0.0f, speed);
        }
        public override Vector2 Think(GameObject gameObject)
        {
            gameObject.SetPosition(ref position);
            position = position + velocity;

            return position;
        }
    }
}
