using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 死亡状态
    /// </summary>
    public class DeadState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Dead;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //禁用状态机
            fsm.enabled = false;
        }
    }

}