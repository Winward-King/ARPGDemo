using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 完成巡逻
    /// </summary>
    public class CompletePatrolTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.isPatrolComplete;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.CompletePatrol;
        }
    }
}