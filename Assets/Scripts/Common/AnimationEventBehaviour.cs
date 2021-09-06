using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	///<summary>
	/// 动画事件行为类
	///</summary>
	public class AnimationEventBehaviour : MonoBehaviour
    {
        //策划：
        // 为动画片段添加事件，指向OnCancelAnim、OnAttack。

        //程序：
        // 在脚本中播放动画，动画中需要执行的逻辑，注册attackHandler事件。

        private Animator anim;

        public event Action AttackHandler;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        //由Unity引擎调用
        private void OnCancelAnim(string animParam)
        {
            anim.SetBool(animParam, false);
        }

        //由Unity引擎调用
        private void OnAttack()
        {
            if (AttackHandler != null)
            {
                AttackHandler();//引发事件
            }
        }
    }
}