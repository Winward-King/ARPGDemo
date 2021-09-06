using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 协程 -- 寻路
/// </summary>
public class CoroutineExample02 : MonoBehaviour
{
    public Transform[] wayPoints;
    public IEnumerator Pathfinding()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            //移动到目标点
            yield return StartCoroutine(MoveToTarget(wayPoints[i].position));
        } 
    }
    public float moveSpeed = 2;
    private IEnumerator MoveToTarget(Vector3 position)
    {
        transform.LookAt(position);
        while (Vector3.Distance(transform.position,position)>0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();//等待一个物理帧
        }
    }
    private void OnGUI()
    {
        if(GUILayout.Button("走你"))
        {
            StartCoroutine(Pathfinding());
        }
    }
}
