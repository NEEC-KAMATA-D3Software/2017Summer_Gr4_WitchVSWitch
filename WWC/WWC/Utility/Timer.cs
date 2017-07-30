using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WWC.Utility
{
    class Timer
    {
        public enum type
        {
            Up, Down
        };
        private float limitTime;
        private float currentTime;
        private float fps = 60;
        private type tp;
        private float sel = 1.0f;

        public Timer(type type)
        {
            tp = type;
            if (type == type.Down) sel = -1.0f;
        }

        public void Initialize(float time)
        {
            switch (tp)
            {
                case type.Up:
                    currentTime = 0.0f;
                    limitTime = fps * time;
                    break;
                case type.Down:
                    currentTime = fps * time;
                    limitTime = 0.0f;
                    break;
            }
        }

        public void Update() { currentTime += sel; }

        public void Update(float time) { currentTime += time * sel; }

        public bool IsTime()
        {
            switch (tp)
            {
                case type.Up:
                    if (currentTime >= limitTime) return true;
                    break;
                case type.Down:
                    if (currentTime <= 0.0f) return true;
                    break;
            }
            return false;
        }

        public float GetTime() { return currentTime; }
    }
}
