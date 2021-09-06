using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 脚本单例类
    /// </summary>
    public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
    {
        //T表示子类类型
        // public static T Instance { get; private set; }
        //按需加载
        private static T instance;
        public static T Instance
        {
            get
            {
                //instance = this as T;
                if(instance == null)
                {
                    //在场景中根据类型查找引用
                    instance = FindObjectOfType<T>();
                    if(instance == null)
                    {
                        instance = new GameObject("Singleton of"+typeof(T)).AddComponent<T>();
                    }
                    else
                    {
                        instance.Init();
                    }
                    //instance.Init();
                }
                return instance;
            }
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }            
        }
        public virtual void Init()
        {

        }

        //备注：
        //1.适用性：场景中存在唯一的对象，即可让该对象继承当前类
        //2.如何适用：
        //  --继承时必须传递子类类型
        //  --在任意脚本生命周期中，通过子类类型访问Instance属性

    }

}