using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WWC.Device;

namespace WWC.Scene
{
    class Ending : IScene
    {
        private InputState input;
        private bool isEnd;
        private IScene gamePlay;
        private Sound sound;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameDevice"></param>
        /// <param name="gamePlay"></param>
        public Ending(GameDevice gameDevice, IScene gamePlay)
        {
            input = gameDevice.GetInputState();
            this.gamePlay = gamePlay;
            isEnd = false;
            sound = gameDevice.GetSound();
        }

        public void Initialize()
        {
            isEnd = false;

        }

        public void Update(GameTime gameTime)
        {
            //sound.PlayBGM("endingbgm");
            if (input.IsKeyDown(Keys.Space))
            {
                //sound.PlaySE("endingse");
                isEnd = true;
            }
        }

        public void Draw(Renderer renderer)
        {
            gamePlay.Draw(renderer);

            renderer.Begin();
            renderer.DrawTexture("ending", new Vector2(150.0f, 150.0f));
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
            return Scene.Title;
        }
    }
}
