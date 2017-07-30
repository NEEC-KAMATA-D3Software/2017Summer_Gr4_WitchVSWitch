using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WWC.Def;
using WWC.Device;
using WWC.GameObject;
using WWC.Scene;

namespace WWC
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;

        private Sound sound;

        private Renderer renderer;
        private GameDevice gameDevice;

        private SceneManager sceneManager;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Game1()
        {　
            // グラフィック機器管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width; //横
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height; //縦
            
            // コンテンツデラクリートの位置
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ここから
            gameDevice = new GameDevice(Content, GraphicsDevice);

            renderer = gameDevice.GetRenderer();
            sound = gameDevice.GetSound();

            #region シーンマネージャー
            ///////////////////////シーンマネージャー//////////////////////////////////////////////////
            sceneManager = new SceneManager();                                                       //
            sceneManager.Add(Scene.Scene.Title, new Title(gameDevice));                              //                                                                                         //
            IScene gamePlay = new GamePlay(gameDevice);                                              //
            sceneManager.Add(Scene.Scene.GamePlay, gamePlay);                                        //
            sceneManager.Add(Scene.Scene.Ending, new Ending(gameDevice, gamePlay));  //
            sceneManager.Change(Scene.Scene.Title);                                                  //  
            ///////////////////////////////////////////////////////////////////////////////////////////
            #endregion

            //ここまで
            base.Window.Title = "ウィチShooting";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent
        /// </summary>
        protected override void LoadContent()
        {

            //画像の読み込み file LOAD
            #region background 背景画像
            renderer.LoadTexture("background");
            renderer.LoadTexture("frontground");
            renderer.LoadTexture("front2ground");
            #endregion

            renderer.LoadTexture("player");
            renderer.LoadTexture("enemy");

            renderer.LoadTexture("boss1");

            renderer.LoadTexture("title");
            renderer.LoadTexture("ending");

            renderer.LoadTexture("bullet");
            renderer.LoadTexture("bossbullet");


            #region sound関連
            //sound.LoadSE("titlese");
            #endregion

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            renderer.Unload();
        }

        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            #region GAME PAD - ゲームコントローラー
            // ゲーム終了処理 게임종료처리
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                    (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                this.Exit();
            }

            //
            #endregion
            //TODO: ここにゲームのアップデートロジックを追加します。
            //入力状態の変更（これは１つしか書かない。複数呼ぶと挙動がおかしくなります）
            gameDevice.Update(gameTime);

            //シーンマネージャーで更新
            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //描画クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sceneManager.Draw(renderer);//シーンマネージャーで描画処理

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
