using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WWC.Device;

namespace WWC.Scene
{
    class SceneManager
    {
        private Dictionary<Scene, IScene> scenes = new Dictionary<Scene, IScene>();
        //現在のシーン
        private IScene currentScene = null;

        public SceneManager()
        { }

        public void Add(Scene name, IScene scene)
        {
            if (scenes.ContainsKey(name))
            {
                return;
            }
            //シーンを追加
            scenes.Add(name, scene);
        }

        public void Change(Scene name)
        {
            if (currentScene != null)
            {
                currentScene.Shutdown();
            }
            //ディクショナリから次のシーンを取り出し、
            //現在のシーンに設定
            currentScene = scenes[name];
            //シーンの初期化
            currentScene.Initialize();
        }
        public void Update(GameTime gameTime)
        {
            if (currentScene == null)
            {
                return;
            }
            //現在のシーンを更新
            currentScene.Update(gameTime);
            //現在のシーンが終了していたか？
            if (currentScene.IsEnd())
            {
                Change(currentScene.Next());
            }
        }
        public void Draw(Renderer renderer)
        {
            //if(currentScene.IsEnd())
            //{
            if (currentScene == null)
            {
                return;
            }
            currentScene.Draw(renderer);
            //}
        }
    }
}
