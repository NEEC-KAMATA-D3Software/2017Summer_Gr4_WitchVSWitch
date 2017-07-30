using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework; //Vector2用
using Microsoft.Xna.Framework.Input; //키보드클레스 사용을위해

namespace WWC.Device
{
    class InputState
    {
        //필드
        public Vector2 velocity = Vector2.Zero; //移動量

        public KeyboardState currentKey;//現在のキー
        public KeyboardState previousKey;//1フレーム前のキー


        ///<summary>
        ///コンストラクタ 콘스트럭터
        ///</summary>
        public InputState()
        { }

        ///<summary>
        ///移動量の取得 이동량의 획득
        /// </summary>
        public Vector2 Velocity()
        {
            return velocity;
        }

        ///<summary>
        ///移動量の変更（このクラス内だけのメソッド、private) 이동량의 변경
        /// </summary>
        /// <param name="keyState">キーボードの状態</param>
        private void UpdateVelocity(KeyboardState keyState)
        {
            velocity = Vector2.Zero; //ゼロで初期化 0으로 초기화


            //keyboard and gamepad(xboxPAD)
            //right
            if (keyState.IsKeyDown(Keys.Right)||GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadRight) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight))
            {
                //動作確認できたら消除 이동확인 됫을시 소거
                velocity.X += 1.0f;
            }
            //left
            if (keyState.IsKeyDown(Keys.Left)||GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadLeft) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                //動作確認できたら消除 이동확인됫을시 소거
                velocity.X -= 1.0f;
            }
            //up
            if (keyState.IsKeyDown(Keys.Up)||GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadUp) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp))
            {
                velocity.Y -= 1.0f;
            }
            //down
            if (keyState.IsKeyDown(Keys.Down)||GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown))
            {
                velocity.Y += 1.0f;
            }

            //正規化 정의화
            if (velocity.Length() != 0.0f)
            {
                velocity.Normalize(); //正規化メソッド 정의화메소드
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyState"></param>
        private void UpdateKey(KeyboardState keyState)
        {
            //
            previousKey = currentKey;
            //
            currentKey = keyState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            bool current = currentKey.IsKeyDown(key);
            bool previous = previousKey.IsKeyDown(key);
            return current && !previous;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetKeyTrigger(Keys key)
        {
            return IsKeyDown(key);
        }

        /// <summary>
        /// キー入力の状態制限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetKeyState(Keys key)
        {
            return currentKey.IsKeyDown(key);
        }

        ///<summary>
        ///変更 변경
        /// </summary>

        public void Update()
        {
            //
            var keyState = Keyboard.GetState();

            //
            UpdateVelocity(keyState);

            //
            UpdateKey(keyState);
        }
    }
}
