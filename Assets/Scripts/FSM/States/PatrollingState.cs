using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public class PatrollingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Patrolling;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //表示：进入巡逻状态时，巡逻没有完成。
            fsm.isPatrolComplete = false;
            fsm.anim.SetBool(fsm.chStatus.chParams.walk, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.chStatus.chParams.walk, false);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);

            //根据巡逻模式
            switch (fsm.patrolMode)
            {
                case PatrolMode.Once:
                    OncePatrolling(fsm);
                    break;
                case PatrolMode.Loop:
                    LoopPatrolling(fsm);
                    break;
                case PatrolMode.PingPong:
                    PingPongPatrolling(fsm);
                    break;
            }
      
          
        
        }
        private int index;
        private void OncePatrolling(FSMBase fsm)
        {
            //-- 单次 A   B    C   
            //是否到达目标点
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
            {
                //到达目标点 
                //如果已经是数组最大索引
                if (index == fsm.wayPoints.Length - 1)
                {
                    //完成巡逻
                    fsm.isPatrolComplete = true;
                    return;//退出
                 }
                index++;
            }
            //走你
            fsm.MoveToTarget(fsm.wayPoints[index].position, 0, fsm.walkSpeed);
        }

        private void LoopPatrolling(FSMBase fsm)
        {
            //-- 循环 A    B    C    A   B    C  ……
            //是否到达目标点
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
            {
                //0       +  1                            3  ==>  1
                //1     +  1                              3  ==>  2
                //2  + 1                                  3  ==>   0
                index = (index + 1) % fsm.wayPoints.Length; 
                //重点：取余可以使一个整数在一个周期内变化
                //今天周四    ==>  100  
                //100  %  7  ==》 2
                //周四 +  2  ==>  周六
            }

            //走你
            fsm.MoveToTarget(fsm.wayPoints[index].position, 0, fsm.walkSpeed);

        }

        private void PingPongPatrolling(FSMBase fsm)
        {
            //-- 往返 A   B   C         B   A   B  C  ……
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
            {
                if (index == fsm.wayPoints.Length - 1)
                {
                    //数组反转
                    Array.Reverse(fsm.wayPoints);
                    index++;
                }
                //A  B  C      C  B  A   A   B   C  
                //0  1   2      0  1  2    0    1    2
                index = (index + 1) % fsm.wayPoints.Length; 
            }
            //走你
            fsm.MoveToTarget(fsm.wayPoints[index].position, 0, fsm.walkSpeed);
        }
    }
}