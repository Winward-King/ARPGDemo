using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
	/// <summary>
	/// 条件类
	/// </summary>
	public abstract class FSMTrigger
	{
        //编号
        public FSMTriggerID TriggerID { get; set; }

        public FSMTrigger()
        {
            Init();
        }

        //要求子类必须初始化条件，为编号赋值。
        public abstract void Init();

        //逻辑处理
        public abstract bool HandleTrigger(FSMBase fsm);
    }
}