using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using WWC.Device;
using WWC.Def;
//using WWC.Utility;


namespace WWC.GameObject
{
    class Player : GameObject
    {
        //宣言
        private InputState inputState; //入力
        private Sound sound;
        private GameObjectManager manager;
        private static int bulletNum;

        //private enum Direction
        //{
        //    DOWN, UP, RIGHT, LEFT
        //};

        //private Direction direction;

        ///<summary>
        ///コンストラクタ
        /// </summary>
        ///<param name="input">白玉はキー入力移動するので、
        ///
        ///</param>
        public Player(InputState input, Sound getSound, GameObjectManager manager) : base("player", 12.0f)
        {
            inputState = input;
            sound = getSound;
            this.manager = manager;
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize()
        {
            position = new Vector2(Screen.Width / 2　- 12.0f, 720.0f);
            bulletNum = 1;

            //motion = new Motion();
            //for (int i = 0; i < 16; i++)
            //{
            //    motion.Add(i, new Rectangle(64 * (i % 4), 64 * (i / 4), 64, 64));
            //}
            //motion.Initalize(new Range(0, 3), new Timer(0.2f));

            //デフォルトposition
            //direction = Direction.DOWN;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

            float speed = 6.5f; //移動速度
            var velocity = inputState.Velocity();
            

            //加速 A key
            if(Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                speed -= 3.5f;
                manager.Add(new Bullet(this.position, new Vector2(0.0f, -5.0f)));
            }
            
                
                //UpdateMotion(velocity);
                position = position + velocity * speed;

            float size = 24.0f;
            var min = Vector2.Zero;
            var max = new Vector2(Screen.Width - size, Screen.Height - size);
            position = Vector2.Clamp(position, min, max);

        }
        public Vector2 GetPosition()
        {
            return position;
        }

        public override void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position);
        }
    }
}
