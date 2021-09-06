using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine01 : MonoBehaviour
{
    private IEnumerator iterator;

    private void OnGUI()
    {
        if(GUILayout.Button("启动"))
        {
           iterator = Fun1();
           
        }
        if(GUILayout.Button("执行一次"))
        {
            iterator.MoveNext();
        }
        if(GUILayout.Button("协程"))
        {
            //StartCoroutine(iterator);
            //每帧调用一次MoveNext方法
            StartCoroutine(Fun1());
        }
    }
    private IEnumerator Fun1()
    {
        for(int i=0;i<5;i++)
        {
            print(i+"---"+Time.frameCount);
            //yield return null;//等待一帧  渲染帧
            yield return new WaitForSeconds(1);//等待1秒
        }
    }
    /*
     * 练习：物体淡出 
     * material fade模式下
     * color a 1-->0
     * 颜色分成多个部分
     */

}
