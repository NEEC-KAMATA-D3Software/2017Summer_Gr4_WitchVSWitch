using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WWC.Def;
using WWC.Device;

namespace WWC.GameObject
{
    class Bullet : GameObject
    {

        public Bullet(Vector2 position, Vector2 velocity) : base("bullet", 4.0f, Vector2.Zero, Vector2.Zero, 3.0f)
        {
            this.velocity = velocity * speed;
            this.position = position;
        }

        public override void Initialize()
        {

        }

        public override void OnCollition(GameObjectManager manager, GameObject other)
        {
            //プレイヤーだったら処理しない
            if (other is Player)
                return;


            //バレットだったら処理しない
            if (other is Bullet)
                return;

            manager.Remove(this);
        }


        //public bool IsPressed(Keys key)
        //{
        //    return (m_KeyState.IsKeyDown(key) && m_prevKeyState.IsKeyUp(key));
        //}

        public override void Update(GameTime gameTime)
        {
            this.position += velocity;

        }//Update END

        public Vector2 Velocity()
        {
            return velocity;
        }
        public bool IsDelete()
        {
            Vector2 objectSize = new Vector2(8.0f, 8.0f);
            if (position != Vector2.Clamp(position, Vector2.Zero - objectSize / 2, new Vector2(540, 720) + objectSize / 2)) return true;
            else return false;
        }

        public bool IsDead() { return isDead; }

        public override void Draw(Renderer renderer)
        {
            //bullet
            if ((IsDelete()) || (isDead)) return;
            renderer.DrawTexture(name, position);
        }

    }
}
