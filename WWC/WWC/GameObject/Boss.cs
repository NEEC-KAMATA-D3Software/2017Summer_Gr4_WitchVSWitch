using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WWC.Device;
using WWC.Def;

namespace WWC.GameObject
{
    class Boss:GameObject
    {
        private AI ai;

        private static Random rand = new Random();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ai"></param>
        public Boss(AI ai) : base("boss1", 60.0f)
        {
            this.ai = ai;
            velocity = ai.Think(this);
            isDead = false;
            Initialize();
        }

        /// <summary>
        /// 初期化 초기화
        /// </summary>
        public override void Initialize()
        {
            position = new Vector2 (Screen.Width/2 - 30, 0);

            //position = new Vector2(rand.Next(0, Screen.Width - 30), 0);
            //rand.Next(0, Screen.Height - 24)

            //velocity = new Vector2(-20.0f, 0.0f);

            //motion = new Motion();

            //for (int i = 0; i < 16; i++)
            //{
            //    motion.Add(i, new Rectangle(64 * (i % 4), 64 * (i / 4), 64, 64));
            //}
            //motion.Initalize(new Range(0, 3), new Timer(0.2f));

            //direction = Direction.DOWN;
        }

        /// <summary>
        /// 更新 갱신
        /// </summary>
        /// <param name="gameTime"><</param>
        public override void Update(GameTime gameTime)
        {

            //黒玉移動処理 반사처리
            position = ai.Think(this);
            //UpdateMotion(velocity);
            //motion.Update(gameTime);
        }
        public void bossIsDead()
        {
            isDead = true;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
        public override void Draw(Renderer renderer)
        {
            //renderer.DrawTexture(name, position, motion.DrawingRange());
            if(isDead == false)
            {
                renderer.DrawTexture(name, position);
            }
        }
    }
}
