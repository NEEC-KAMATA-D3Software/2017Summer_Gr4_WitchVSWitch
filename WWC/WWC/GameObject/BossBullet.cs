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
    class BossBullet : GameObject
    {
        //private Sound sound;
        public AI ai;
        public Vector2[] vectorBulletPosition2;
        public bool[] blsFire2;
        public int currentBulletNumber2;
        public int maxBulletCount2 = 100;

        public float fireDelay2 = 0.0f;
        public float rateofFire2 = 2.0f;

        private int count;

        //KeyboardState m_KeyState;
        //KeyboardState m_prevKeyState;

        public BossBullet(AI ai) : base("bossbullet", 4.0f)
        {
            this.ai = ai;
        }

        public override void Initialize()
        {
            //弾丸の初期化
            vectorBulletPosition2 = new Vector2[maxBulletCount2];
            blsFire2 = new bool[maxBulletCount2];
            currentBulletNumber2 = 0;
        }

        //public bool IsPressed(Keys key)
        //{
        //    return (m_KeyState.IsKeyDown(key) && m_prevKeyState.IsKeyUp(key));
        //}

        public override void Update(GameTime gameTime)
        {

            position = ai.Think(this);

            for (int i=0; i<100; i++)
            {
                count -= 1;
            }
            //弾丸撃つ処理
            //if (IsPressed(Keys.Z) == true)
            if (count < 0)
            {

                fireDelay2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;

                if (fireDelay2 >= rateofFire2)
                {

                    blsFire2[currentBulletNumber2] = true;

                    //bossの位置にbulletを合わせる
                    vectorBulletPosition2[currentBulletNumber2] = position;
                    vectorBulletPosition2[currentBulletNumber2].Y = position.Y + 50.0f;
                    vectorBulletPosition2[currentBulletNumber2].X = position.X + 56.0f;


                    currentBulletNumber2++;
                    //sound.PlaySE("titlese");
                    if (currentBulletNumber2 >= maxBulletCount2)
                    {
                        currentBulletNumber2 = 0;
                        fireDelay2 = 0.0f;
                    }
                }
            }
            else
            {
                fireDelay2 = 0.0f;
            }
            float moveDistanceBullet = 400.0f * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            for (int bulletNumber2 = 0; bulletNumber2 < maxBulletCount2; bulletNumber2++)
            {
                if (blsFire2[bulletNumber2] == true)
                {
                    vectorBulletPosition2[bulletNumber2].Y += moveDistanceBullet;
                    
                }
                //if (vectorBulletPosition[bulletNumber].X > Screen.Width || vectorBulletPosition[bulletNumber].Y > Screen.Height
                //    || vectorBulletPosition[bulletNumber].X < 0.0f || vectorBulletPosition[bulletNumber].Y < 0.0f)
                //{
                //    blsFire[bulletNumber] = false;
                //}
            }
        }//Update END

        public void BulletPosUpdate(Vector2 position)
        {
            this.position = position;
        }

        public override void Draw(Renderer renderer)
        {
            //bullet
            for (int bulletNumber2 = 0; bulletNumber2 < maxBulletCount2; bulletNumber2++)
            {
                renderer.DrawTexture(name, vectorBulletPosition2[bulletNumber2]);
            }
        }
    }
}

