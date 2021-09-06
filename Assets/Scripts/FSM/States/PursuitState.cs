using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 追逐
    /// </summary>
    public class PursuitState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Pursuit;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsm.anim.SetBool(fsm.chStatus.chParams.run, true);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            fsm.MoveToTarget(fsm.targetTF.position, fsm.chStatus.attackDistance, fsm.runSpeed);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //停止移动
            fsm.StopMove();
            fsm.anim.SetBool(fsm.chStatus.chParams.run, false); 
        }
    }
}