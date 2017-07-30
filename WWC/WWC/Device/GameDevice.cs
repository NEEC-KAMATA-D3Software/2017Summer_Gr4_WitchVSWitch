using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WWC.Device
{
    class GameDevice
    {
        private Renderer renderer;
        private InputState input;
        private Sound sound;
        private static Random rand;

        public GameDevice(ContentManager contentManager, GraphicsDevice graphics)
        {
            renderer = new Renderer(contentManager, graphics);
            input = new InputState();
            sound = new Sound(contentManager);
            rand = new Random();
        }

        public void Initizlize()
        {

        }

        public void Update(GameTime gameTime)
        {
            input.Update();
        }

        public Renderer GetRenderer()
        {
            return renderer;
        }

        public InputState GetInputState()
        {
            return input;
        }

        public Sound GetSound()
        {
            return sound;
        }

        public Random GetRandom()
        {
            return rand;
        }
    }
}

