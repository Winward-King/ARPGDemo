using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 默认状态
    /// </summary>
    public class IdleState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Idle;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //播放待机动画
            fsm.anim.SetBool(fsm.chStatus.chParams.idle, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //播放待机动画
            fsm.anim.SetBool(fsm.chStatus.chParams.idle, false);
        }
    }
}