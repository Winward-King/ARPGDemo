using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
	public void Fire()
    {
        //ResourceManager
        //创建物体——》设置位置/旋转——》立即执行Awake(计算目标点)
        //Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObjectPool.Instance.CreateObject("bullet", bulletPrefab, transform.position, transform.rotation);
    }
    //**********测试**********
    private void OnGUI()
    {
        if (GUILayout.Button("发射炮弹"))
        {
            Fire();
        }
        if (GUILayout.Button("清空类别"))
        {
            GameObjectPool.Instance.Clear("bullet");
        }
        if (GUILayout.Button("清空全部"))
        {
            GameObjectPool.Instance.ClearAll();
        }
    }
}
