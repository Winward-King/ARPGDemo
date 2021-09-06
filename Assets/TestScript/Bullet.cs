using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Bullet : MonoBehaviour,IResetable
{
    private Vector3 targetPos;

    //创建对象时执行一次
    //private void Awake()
    //{
    //    //计算正前方50m的世界坐标
    //    //TransformPoint ：自身坐标系---》世界坐标系
    //    targetPos = transform.TransformPoint(0, 0, 50);
    //}

    //每次通过对象池创建时执行一次
    public void OnReset()
    {
        targetPos = transform.TransformPoint(0, 0, 50);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 50);
        if((Vector3.Distance(transform.position,targetPos))<0.1)
        {
            //Destroy(gameObject);
            GameObjectPool.Instance.CollectObject(gameObject,5);
            //Destroy(new List<int>());
            //System.Object        object  int List<string>
            //UnityEngine.Object   Object  模型 贴图 组件

        }
    }
    
}
