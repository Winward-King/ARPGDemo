using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private void Start()
    {
        //XXManager.Instance.  点不出Fun1方法
        XXManager.Instance.Fun1();
    }
}
