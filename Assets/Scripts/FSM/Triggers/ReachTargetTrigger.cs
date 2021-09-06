using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 目标进入攻击范围
    /// </summary>
    public class ReachTargetTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            //计算 状态机位置 与  目标位置  间距  
            //与 角色攻击距离比较
            if (fsm.targetTF == null) return false;
            return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) <= fsm.chStatus.attackDistance;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.ReachTarget;
        }
    }
}