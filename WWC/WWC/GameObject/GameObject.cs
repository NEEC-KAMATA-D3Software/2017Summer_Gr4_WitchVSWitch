using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using WWC.Device;

namespace WWC.GameObject
{
    abstract class GameObject
    {
        protected string name;
        protected Vector2 position;
        protected Vector2 velocity;
        protected int hp;
        protected float speed;
        protected float radius;
        protected bool isDead; //ボコされたか

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="radius"></param>
        public GameObject(string name, float radius)
        {
            this.name = name;
            this.radius = radius;
            isDead = false;
        }

        public GameObject(string name, float radius,Vector2 position, Vector2 velocity, float speed)
        {
            this.name = name;
            this.velocity = velocity;
            this.position = position;
            this.radius = radius;
            this.speed = speed;
            isDead = false;
        }

        /// <summary>
        /// 抽象初期化メソッド
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// 抽象更新メソッド
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="renderer"></param>
        public virtual void Draw(Renderer renderer) //virtual追加
        {
            renderer.DrawTexture(name, position);
        }

        public virtual void OnCollition(GameObjectManager maanger, GameObject other)
        {

        }

        /// <summary>
        /// Collition
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCollition(GameObject other)
        {
            //中心座標の計算　중심좌표의 계산
            Vector2 myCenter = position + new Vector2(radius, radius);
            Vector2 otherCenter = other.position + new Vector2(other.radius, other.radius);

            //상대의 캐릭터의X,Y의 여러가지의 길이
            float xLength = myCenter.X - otherCenter.X;
            float yLength = myCenter.Y - otherCenter.Y;

            //두점간의 거리의 2배의위치
            float squareLegth = xLength * xLength + yLength * yLength;

            //半径　반경
            float squareRadius = (radius + other.radius) * (radius + other.radius);

            //半径比較、当たるか?当たらないか?　반경 비교, 맞는지?안맞는지?
            if (squareLegth <= squareRadius) return true;
            else return false; //衝突していない
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void SetPosition(ref Vector2 other)
        {
            other = position;
        }
    }
}
