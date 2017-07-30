using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using WWC.Device;
using WWC.GameObject;
using WWC.Utility;
using WWC.Def;

namespace WWC.Scene
{
    class GamePlay : IScene
    {
        private GameDevice gameDevice;
        private bool isEnd;

        //private Player player;

        //player bullet 関連
        //private List<Bullet> playerBullets;
        private Timer bulletTimer;

        //private Enemy enemy1;
        //private Enemy enemy2;
        //private Boss boss1;
        //private BossBullet bossBullet1;
        //private List<Enemy> enemy_zako;

        private GameObjectManager objManager = new GameObjectManager();

        //private Random ran;


        private int nBackgroundY = 0; //Back背景Y
        private int nFront1groundY = 0; //Front背景Y
        private int nFront2groundY = 0; //Front背景Y

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameDevice"></param>
        public GamePlay(GameDevice gameDevice)
        {
            this.gameDevice = gameDevice;
            isEnd = false;
            //sound = gameDevice.GetSound();
            bulletTimer = new Timer(Timer.type.Down);

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            isEnd = false;

            //ゲームオブジェクト生成
            objManager.Add(new Player(gameDevice.GetInputState(), gameDevice.GetSound(), objManager));
            objManager.Add(new Enemy(new BoundAI()));
            objManager.Add(new Enemy(new TotugekiAI()));
            objManager.Add(new Boss(new BossAI()));

            objManager.Init();


            //ゲームデバイスから入力オブジェクトを取得し、Playerの実体生成
            //player = new Player(gameDevice.GetInputState(), gameDevice.GetSound());
            //player.Initialize();

            //playerBullets = new List<Bullet>();
            //bulletTimer.Initialize(0.05f);

            ////enemyの初期化
            //enemy1 = new Enemy(new BoundAI());
            //enemy1.Initialize();
            //enemy2 = new Enemy(new TotugekiAI());
            //enemy2.Initialize();

            //enemy_zako = new List<Enemy>();
            //for (int i = 0; i < 2; i++)
            //{
            //    enemy_zako.Add(new Enemy(new TotugekiAI()));
            //}
            //foreach (var b in enemy_zako)
            //{
            //    b.Initialize();
            //}

            ////bossの初期化
            //boss1 = new Boss(new BossAI());
            //boss1.Initialize();
            //bossBullet1 = new BossBullet(new TotugekiAI());
            //bossBullet1.Initialize();
        }

        /// <summary>
        ///　更新
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            
            //back
            nBackgroundY +=5;
            if (nBackgroundY >= 720)
            {
                nBackgroundY = 0;
            }
            //front1
            nFront1groundY +=5;
            if (nFront1groundY >= 720)
            {
                nFront1groundY = 0;
            }
            //front2:cloud
            nFront2groundY += 2;
            if (nFront2groundY >= 720)
            {
                nFront2groundY = 0;
            }

            objManager.Update(gameTime);

            //player更新
            //player.Update(gameTime);
            ////playerBullets.ForEach((Bullet b) => b.Update(gameTime));

            ////enemy更新
            //enemy1.Update(gameTime);
            //enemy2.Update(gameTime);
            //enemy_zako.ForEach((Enemy b) => b.Update(gameTime));

            ////boss更新
            //boss1.Update(gameTime);

            ////if (playerBullet.IsCollition(boss1))
            ////{
            ////    boss1.bossIsDead();
            ////    playerBullet.IsDelete();
            ////}
            //bulletTimer.Update();

            //if ((Keyboard.GetState().IsKeyDown(Keys.Z)) && (bulletTimer.IsTime()))
            //{
            //        Vector2 velocity = new Vector2(0.0f, 1.0f);
            //        Bullet b = new Bullet();
            //        b.Initialize(player.GetPosition(), velocity);

            //        playerBullets.Add(b);
            //    bulletTimer.Initialize(0.05f);
            //}
            //playerBullets.ForEach((Bullet b) => b.Update(gameTime));

            ////bossBullet更新
            //bossBullet1.BulletPosUpdate(boss1.GetPosition());
            //bossBullet1.Update(gameTime);
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.Begin();

            #region ground 背景
            //background back
            renderer.SqDrawTexture(
                "background", 
                new Rectangle(0, 0, 540, nBackgroundY), 
                new Rectangle(0, 720-nBackgroundY, 540, nBackgroundY));

            renderer.SqDrawTexture(
                "background", 
                new Rectangle(0, nBackgroundY, 540, 720), 
                new Rectangle(0, 0, 540, 720));

            //background front1
            renderer.SqDrawTexture(
                "frontground",
                new Rectangle(0, 0, 540, nFront1groundY),
                new Rectangle(0, 720 - nFront1groundY, 540, nFront1groundY));

            renderer.SqDrawTexture(
                "frontground",
                new Rectangle(0, nFront1groundY, 540, 720),
                new Rectangle(0, 0, 540, 720));

            //background front2
            renderer.SqDrawTexture(
                "front2ground",
                new Rectangle(0, 0, 540, nFront2groundY),
                new Rectangle(0, 720 - nFront2groundY, 540, nFront2groundY));

            renderer.SqDrawTexture(
                "front2ground",
                new Rectangle(0, nFront2groundY, 540, 720),
                new Rectangle(0, 0, 540, 720));
            #endregion


            objManager.Draw(renderer);
            //player.Draw(renderer);
            //playerBullets.ForEach((Bullet b) => b.Draw(renderer));

            //enemy1.Draw(renderer);
            //enemy2.Draw(renderer);
            //enemy_zako.ForEach((Enemy b) => b.Draw(renderer));

            //boss1.Draw(renderer);
            //bossBullet1.Draw(renderer);

            renderer.End();
        }

        public void Shutdown()
        {
            //sound.StopBGM();
        }

        public bool IsEnd()
        {
            return isEnd;
        }

        public Scene Next()
        {
            return Scene.Ending;
        }
    }
}
