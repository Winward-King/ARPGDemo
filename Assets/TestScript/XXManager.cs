using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 管理类：1.唯一 
///         2.常用
///         
/// </summary>
public class XXManager : MonoSingleton<XXManager>
{

    //private void Start()
    //{
    //    //FindObjectOfType<XXManager>().?
    //}

    //public static XXManager Instance { get; private set; }
    //private void Awake()
    //{
    //    Instance = this;
    //}
    //缺点：
    //1.代码重复
    //2.由于在Awake赋值，所以客户端代码只能在Awake以后的脚本生命周期中访问
    
    //解决方案：定义MonoSingleton类
    //1.适用性：场景中存在唯一的对象，即可让该对象继承当前类
    //2.如何适用：
    //  --继承时必须传递子类类型
    //  --在任意脚本生命周期中，通过子类类型访问Instance属性
    public void Fun1()
    {
        print("Fun1");
    }
}
