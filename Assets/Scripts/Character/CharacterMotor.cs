using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 角色马达：负责控制角色移动
    /// </summary>

public class CharacterMotor : MonoBehaviour
    {
        /// <summary>
        /// 代码中有提示
        /// </summary>
        [Tooltip("移动速度")] //编译器中有提示
        public float moveSpeed = 2f;
        [Tooltip("旋转速度")]
        public float rotationSpeed = 20f;
        
        private CharacterController controller;

        /// <summary>
        /// 开始寻找 不用重复 节约性能
        /// </summary>
        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        //注视目标方向旋转
        public void LookAtTarget(Vector3 direction)
        {
            if (direction == Vector3.zero) return;//短路写法，四元数必须是个向量，如果为零时是个点
            //看向
            Quaternion lookDirection = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection,Time.deltaTime * rotationSpeed);//1初始 2目标 3速度比例变量

            //transform.rotation = Quaternion.LookRotation(direction);
            //Quaternion.Lerp
        }

	    //移动
        public void Movement(Vector3 direction)
        {
            LookAtTarget(direction);
            //补充代码 重力
            Vector3 forward = transform.forward;
            forward.y = -1;//相当于重力
            //向前移动
            //CharacterController Move
            controller.Move(forward * Time.deltaTime * moveSpeed);

        }

  }
}