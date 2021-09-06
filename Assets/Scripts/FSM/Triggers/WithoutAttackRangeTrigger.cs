using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 离开攻击范围
    /// </summary>
    public class WithoutAttackRangeTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
           return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) > fsm.chStatus.attackDistance;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.WithoutAttackRange;
        }
    }
}