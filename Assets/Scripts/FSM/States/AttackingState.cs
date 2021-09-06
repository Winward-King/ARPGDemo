using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class AttackingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Attacking;
        }

        private float atkTime;
        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);

            if (atkTime <= Time.time)
            {
                fsm.skillSystem.UseRandomSkill();
                atkTime = Time.time + fsm.chStatus.attackInterval ;
            }
        }
    }
}