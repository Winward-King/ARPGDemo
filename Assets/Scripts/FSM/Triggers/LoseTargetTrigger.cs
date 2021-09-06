using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 丢失目标
    /// </summary>
    public class LoseTargetTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.targetTF == null;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.LoseTarget;
        }
    }
}