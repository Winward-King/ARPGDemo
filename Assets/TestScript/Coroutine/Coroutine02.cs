using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Coroutine02 : MonoBehaviour
    {
    // a1 b1 d1 f1……c100 e100
        private Coroutine coroutine;
        private void Start()
        {
            print("a:" + Time.frameCount);
            coroutine = StartCoroutine(Fun1());
            print("d:" + Time.frameCount);
            StartCoroutine(Fun2());
            print("f:" + Time.frameCount);
        }

        private IEnumerator Fun1()
        {
            print("b:" + Time.frameCount);
            yield return new WaitForSeconds(2);
            print("c:" + Time.frameCount);
        }
        private IEnumerator Fun2()
        {
            yield return coroutine;
            print("e:" + Time.frameCount);
      
        }
    /*
     * 通过协程实现寻路 A B C……
     * transform
     *   transform.position = Vector3.MoveTowards(起点 ,终点, 速度);

 *      */
}



