using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /*
     * 使用方式：
     * 1.所有频繁创建/销毁的物体，都通过对象池创建回收
     *  GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotate)
     *                          （“类别”，预制件，位置，旋转）
     *  GameObjectPool.Instance.CreateObject("bullet", bulletPrefab, transform.position, transform.rotation);
     *                           （游戏对象）
     * 2.需要通过对象池创建的物体，如需每次创建时执行，则让脚本实现IResetable接口
     */

    /// <summary>
    /// 通过对象池 创建对象
    /// </summary>
    public interface IResetable
    {
        void OnReset();
    }
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        //对象池
        private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();

        public override void Init()
        {
            base.Init();
            //cache = new Dictionary<string, List<GameObject>>();
            //提出去，否则报错（与教程不同）
        }
        /// <summary>
        /// 通过对象池创建对象
        /// </summary>
        /// <param name="key">类别</param>
        /// <param name="prefab">需要创建实例的预制件</param>
        /// <param name="pos">位置</param>
        /// <param name="rotation">旋转</param>
        /// <returns></returns>
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotate)
        {
           
            //创建游戏对象
            GameObject go = FindUseableObject(key);
            if (go == null)
            {
               
                go = AddObject(key, prefab);//创建物体——》Awake ——》
                Debug.Log("Prefab" + "+" + prefab.name);
            }
            UseObject(pos, rotate, go);//设置位置/旋转
            return go;
        }
        //查找指定类别中可以使用的对象
        private GameObject FindUseableObject(string key)
        {
            if (cache.ContainsKey(key))
            {
                return cache[key].Find(g => !g.activeInHierarchy);
            }
            return null;
        }
        //添加对象
        private GameObject AddObject(string key, GameObject prefab)
        {
            
            //创建对象
            GameObject go = Instantiate(prefab);
            Debug.Log("Prefab" + "+" + prefab.name);
            //if (cache.ContainsKey(key))
            //    cache[key].Add(go);
            //else
            //{
            //    cache.Add(key, new List<GameObject>());
            //    cache[key].Add(go);
            //}
            //如果池中没有key则添加记录
            if (cache == null||!cache.ContainsKey(key))
            {
                cache.Add(key, new List<GameObject>());
            }
            cache[key].Add(go);
            return go;
        }
        //使用对象
        private static void UseObject(Vector3 pos, Quaternion rotate, GameObject go)
        {
            //使用
            go.transform.position = pos;
            go.transform.rotation = rotate;
            go.SetActive(true);
            //设置目标点
            //go.GetComponent<Bullet>().方法（）;
            //抽象 类（找父类） 接口（） 委托 （钩子） ——》
            //抽象
            //go.GetComponent<IResetable>().OnReset();
            //遍历执行物体中所有需要重置的逻辑
            foreach (var item in go.GetComponents<IResetable>())
            {
                item.OnReset();
            }
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="go">需要被回收的游戏对象</param>
        /// <param name="delay">延迟事件 默认为0</param>
        public void CollectObject(GameObject go,float delay)
        {
            //go.SetActive(false);
            StartCoroutine(CollectObjectDelay(go, delay));
        }

        private IEnumerator CollectObjectDelay(GameObject go,float delay)
        {
            yield return new WaitForSeconds(delay);
            print("破坏");
            go.SetActive(false);

        }
        /// <summary>
        /// 清空某个类别
        /// </summary>
        /// <param name="key"></param>
        public void Clear(string key)
        {
            //Destroy(游戏对象);
            //cache[key]   -->  List<GameObject>
            if(cache!=null)
            {
                for (int i = 0; i < cache[key].Count; i++)
                {
                    Destroy(cache[key][i]);
                }

                //for (int i = cache[key].Count - 1; i >= 0; i--)
                //{
                //    Destroy(cache[key][i]);
                //}
                //foreach (var item in cache[key])
                //{
                //    Destroy(item);
                //}
                //类别
                cache.Remove(key);
            }

        

            
        }
        //清空全部
        public void ClearAll()
        {
            //遍历 字典 集合
            //foreach (var key in cache.Keys)
            //{
            //    Clear(key);//删除字典记录 cache.Remove
            //}
            foreach (var key in new List<string>(cache.Keys))
            {
                Clear(key);//删除字典记录 cache.Remove(key);
            }
        }
    }
}
