using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WWC.Def;

namespace WWC.GameObject
{
    class BossAI:AI
    {
        private Vector2 velocity;
        public BossAI()
        {
            //左移動
            velocity = new Vector2(-10.0f, 0.0f);
        }

        public override Vector2 Think(GameObject gameObject)
        {
            //
            gameObject.SetPosition(ref position);

            //
            position = position + velocity;

            float size = 120.0f;
            //
            if (position.X < 0.0f)
            {
                velocity = new Vector2(2.0f, 0.0f);
            }
            if (position.X > Screen.Width - size)
            {
                velocity = new Vector2(-2.0f, 0.0f);
            }
            return position;
        }
    }
}
