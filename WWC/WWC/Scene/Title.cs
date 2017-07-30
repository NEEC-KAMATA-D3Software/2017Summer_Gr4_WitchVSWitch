using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WWC.Device;

namespace WWC.Scene
{
    class Title : IScene　//シーンインタフェース
    {
        private InputState input;
        private Sound sound;
        private bool isEnd;//シーン終了フラグ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameDevice"></param>
        public Title(GameDevice gameDevice)
        {
            input = gameDevice.GetInputState();
            sound = gameDevice.GetSound();
            isEnd = false;

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            isEnd = false;

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTimer"></param>
        public void Update(GameTime gameTime)
        {
            //sound.PlayBGM("titlebgm");
            if (input.GetKeyTrigger(Keys.Space))
            {
                //sound.PlaySE("titlese");
                isEnd = true;
            }
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("title", Vector2.Zero);
            //renderer.DrawTexture("puddle", new Vector2(200f, 370f), motion.DrawingRange());
            renderer.End();
        }

        /// <summary>
        /// シーンが終了したか？
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            return isEnd;
        }

        /// <summary>
        /// 次のシーン名を返す
        /// </summary>
        /// <returns></returns>
        public Scene Next()
        {
            //次のシーンはゲームプレイ
            return Scene.GamePlay;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Shutdown()
        {
            sound.StopBGM();
        }
    }
}
