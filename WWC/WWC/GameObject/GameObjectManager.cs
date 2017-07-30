using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WWC.GameObject
{
    class GameObjectManager
    {
        List<GameObject> objContainer = new List<GameObject>();
        List<GameObject> deleteContainer = new List<GameObject>();

        public GameObjectManager()
        {

        }

        public void Add(GameObject newObj)
        {
            objContainer.Add(newObj);
        }

        public void Remove(GameObject delteObj)
        {
            
            deleteContainer.Add(delteObj);
        }

        private void CheckDelete()
        {

            foreach (var deleteObj in deleteContainer)
            {
                //一致するインスタンスをｐ削除
                objContainer.RemoveAll((GameObject obj) =>
                {                 
                    return obj.getNum() == deleteObj.getNum();
                });
            }

            deleteContainer.Clear();
        }


        public void Init()
        {
            foreach (var obj in objContainer)
            {
                obj.Initialize();
            }

        }

        private void CollitionCheck()
        {
            foreach (var obj in objContainer)
            {
                foreach (var obj2 in objContainer)
                {
                    if(obj.IsCollition(obj2)){
                        obj.OnCollition(this,obj2);
                    }
                }
            }
        }


        public void Update(GameTime time)
        {
            CheckDelete();
            for (int i = 0; i != objContainer.Count; ++i)
            {
                objContainer[i].Update(time);
            }
            CollitionCheck();

        }


        public void Draw(Device.Renderer renderer)
        {
            foreach (var obj in objContainer)
            {
                obj.Draw(renderer);
            }
        }



    }
}
