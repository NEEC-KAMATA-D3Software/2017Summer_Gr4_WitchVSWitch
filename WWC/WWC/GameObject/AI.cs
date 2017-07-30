﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WWC.GameObject
{
    abstract class AI
    {
        protected Vector2 position;
        public AI()
        {
            position = Vector2.Zero;
        }

        public abstract Vector2 Think(GameObject gameObject);
    }
}
