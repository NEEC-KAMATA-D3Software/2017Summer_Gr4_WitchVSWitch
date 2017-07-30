using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics; //Assert用
using WWC.Scene;

namespace WWC.Device
{
    class Renderer
    {
        private ContentManager contentManager; //コンテント管理者
        private GraphicsDevice graphicsDevice; //グラフィック管理者
        private SpriteBatch spriteBatch; //スプライトバッチ

        //Dicで複数の画像を管理
        private Dictionary<string, Texture2D> textures
            = new Dictionary<string, Texture2D>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
        /// <summary>
        /// 画像の読み込み
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filepath"></param>
        public void LoadTexture(string name, string filepath = "./")
        {
            //ガード
            if (textures.ContainsKey(name))
            {
#if DEBUG //DEBUGモードの時のみ有効
                System.Console.WriteLine("この" + name + "はkeyで、すでに登録しています");
#endif
                //処理終了
                return;
            }
            //画像の読み込みとDictionaryにアセット名と画像の追加
            textures.Add(name, contentManager.Load<Texture2D>(filepath + name));
        }

        /// <summary>
        /// 画像の登録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        public void LoadTexture(string name, Texture2D texture)
        {
            //ガード
            if (textures.ContainsKey(name))
            {
#if DEBUG //DEBUGモードの時のみ有効
                System.Console.WriteLine("この" + name + "はkeyで、すでに登録しています");
#endif
                //処理終了
                return;
            }
            //画像の読み込みとDictionaryにアセット名と画像の追加
            textures.Add(name, texture);
        }

        /// <summary>
        /// unload
        /// </summary>
        public void Unload()
        {
            textures.Clear();
        }

        /// <summary>
        /// 描画開始
        /// </summary>
        public void Begin()
        {
            spriteBatch.Begin();
        }

        /// <summary>
        /// 描画終了
        /// </summary>
        public void End()
        {
            spriteBatch.End();
        }

        /// <summary>
        /// 画像の描画
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="alpha"></param>
        public void DrawTexture(string name, Vector2 position, float alpha = 1.0f)
        {
            //
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間連えていませんか？\n" +
                "大文字小文字間連ってませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください");

            spriteBatch.Draw(
                textures[name], 
                position, 
                Color.White * alpha);
        }

        /// <summary>
        /// スクロール描画
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="alpha"></param>
        public void SqDrawTexture(string name, Rectangle rect, Rectangle rect2, float alpha = 1.0f)
        {
            //
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間連えていませんか？\n" +
                "大文字小文字間連ってませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください");

            spriteBatch.Draw(
                textures[name],
                rect,
                rect2,
                Color.White * alpha);
        }

        /// <summary>
        /// 画像の描画(指定範囲)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="rect"></param>
        /// <param name="alpha"></param>
        public void DrawTexture(string name, Vector2 position, Rectangle rect, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間連えていませんか？\n" +
                "大文字小文字間連ってませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください");

            spriteBatch.Draw(
                textures[name],
                position,
                rect,
                Color.White * alpha);
        }
        /// <summary>
        /// 画像の描画　fade in/outのための描画
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="alpha"></param>
        public void DrawTexture(string name, Vector2 position, Vector2 scale, float alpha = 1.0f)
        {
            //
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間連えていませんか？\n" +
                "大文字小文字間連ってませんか？\n" +
                "LoadTextureメソッドで読み込んでいますか？\n" +
                "プログラムを確認してください");

            spriteBatch.Draw(
                textures[name],
                position,
                null,
                Color.White * alpha,
                0.0f,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                0.0f
                );
        }
        public void DrawNumber(string name, Vector2 position, int number, float alpha = 1.0f)
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n",
                "大文字小文字間違っていませんか？\n",
                "LoadTextureメソッドで読み込んでいますか？\n",
                "プログラムを確認してください\n");
            //
            if (number < 0)
            {
                number = 0;
            }

            foreach (var n in number.ToString())
            {
                spriteBatch.Draw(
                    textures[name],
                    position,
                    new Rectangle((n - '0') * 32, 0, 32, 64),
                    Color.White * alpha
                    );
                position.X += 32;
            }
        }

        public void DrawCountNumber(string name, Vector2 position, int number, float alpa = 1.0f)//문자열형 다중정의
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n",
                "大文字小文字間違っていませんか？\n",
                "LoadTextureメソッドで読み込んでいますか？\n",
                "プログラムを確認してください\n");
            //
            for (int i = 0; i > 3; i++)
            {
                spriteBatch.Draw(
                    textures[name],
                    position,
                    new Rectangle(26 * 32, 0, 32, 64),
                    Color.White * alpa
                    );

                //表示座標のX座標を右へ移動
                position.X += 32;
            }
        }//DCN end

        public void DrawNumber(string name, Vector2 position, string number, int digit, float alpa = 1.0f)//문자열형 다중정의
        {
            Debug.Assert(
                textures.ContainsKey(name),
                "アセット名が間違えていませんか？\n",
                "大文字小文字間違っていませんか？\n",
                "LoadTextureメソッドで読み込んでいますか？\n",
                "プログラムを確認してください\n");
            //
            for (int i = 0; i < digit; i++)
            {
                if (number[i] == '.')
                {
                    //
                    spriteBatch.Draw(
                        textures[name],
                        position,
                        new Rectangle(10 * 32, 0, 32, 64),
                        Color.White * alpa
                        );
                }//ifend
                else
                {
                    //
                    char n = number[i];

                    //
                    spriteBatch.Draw(
                        textures[name],
                        position,
                        new Rectangle((n - '0') * 32, 0, 32, 64),
                        Color.White * alpa
                        );
                }//else end
                //表示座標のX座標を右へ移動
                position.X += 32;
            }
        }//DNend
    }//class Rander end
}//namespace end
