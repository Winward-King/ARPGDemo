using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CoroutineExample01 : MonoBehaviour {
    //private Color a;
    private Material mt;
	// Use this for initialization
	void Start () {
        mt = GetComponent<MeshRenderer>().material;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float fadeSpeed = 10;
    //淡出
    public IEnumerator FadeoutTest()
    {
        // a    1 ---> 0
        //mt.color.a = 1;
        Color currentColor = mt.color;
        do
        {
            currentColor.a -= fadeSpeed * Time.deltaTime;
            mt.color = currentColor;
            //将方法分成多个部分 
            yield return null;
        } while (currentColor.a > 0);//可能点不到0 和 速度也有关
        currentColor.a = 0;
        mt.color = currentColor;
    }

    //颜色渐变
    public Color endColor;
    public AnimationCurve curve;
    private float x;
    public float time = 1;
    public IEnumerator Fadeout()
    {
        Color originalColor = mt.color;

        //x += Time.deltaTime;
        for (float x = 0; x <=1;x +=Time.deltaTime/time)
        {
            float y = curve.Evaluate(x);
            mt.color = Color.Lerp(originalColor, endColor, y);
            yield return null;
            //Vector3.Lerp
            //Quaternion.Lerp
        }
       //动画曲线AnimationCurve的作用：提供数值可视化的操作面板
       //颜色差值Color.Lerp的作用：将数值的变化转化为颜色的变化
    }

    private void OnGUI()
    {
        if (GUILayout.Button("淡出"))
        {
            StartCoroutine(Fadeout());
        }
    }
}
