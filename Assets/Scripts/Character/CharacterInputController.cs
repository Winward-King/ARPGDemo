using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPGDemo;
using ARPGDemo.Skill;

namespace ARPGDemo.Character
    {
    /// <summary>
    /// 角色输入控制器
    /// </summary>
public class CharacterInputController : MonoBehaviour
    {

        private ETCJoystick joystick;
        private CharacterMotor chMotor;
        private Animator anim;
        private PlayerStatus status;
        private ETCButton[] skillButtons;
        private CharacterSkillSystem skillSystem;

        private void Awake()
        {
            //查找组件
            joystick = FindObjectOfType<ETCJoystick>();
            chMotor = GetComponent<CharacterMotor>();
            anim = GetComponentInChildren<Animator>();//获取player下子组件
            status = GetComponent<PlayerStatus>();//获取类
            skillButtons = FindObjectsOfType<ETCButton>();//获取按键组
            skillSystem = GetComponent<CharacterSkillSystem>();
            //GetComponentInChildren
            //GetComponentInParent
        }
        private void OnEnable()
        {
            //注册事件
            joystick.onMove.AddListener(OnJoystickMove);
            joystick.onMoveStart.AddListener(OnJoystickMoveStart);
            joystick.onMoveEnd.AddListener(OnJoystickMoveEnd);

            for(int i=0;i<skillButtons.Length;i++)
            {
                if (skillButtons[i].name == "BaseButton")
                    skillButtons[i].onPressed.AddListener(OnSkillButtonPressed);
                else
                    skillButtons[i].onDown.AddListener(OnSkillButtonDown);
            }
        }

        private float lastPressTime = -1;
        //当按住普攻键时执行
        private void OnSkillButtonPressed()
        {
            

            //需求：按住间隔如果过小（2） 则取消攻击
            //间隔小于5秒视于连击

            //间隔：当前按下时间 - 最后按下时间
            float interval = Time.time -lastPressTime;
            if (interval < 2) return;
            bool isBatter = interval <= 5;
            // if(interval<=5)
            //{
            //    isBatter = true;
            //}
            // else
            //{
            //    isBatter = false;
            //}
            skillSystem.AttackUseSkill(1001,isBatter);

            lastPressTime = Time.time;
        }

        private void OnSkillButtonDown(string name)
        {
            int id = 0;
            switch (name)
            {
                //case "BaseButton":
                //    id = 1001;
                //    break;
                case "SkillButton01":
                    id = 1002;
                    break;
                case "SkillButton02":
                    id = 1003;
                    break;
            }
            //print(name + "+" + "打死你" + "+" + id);
            //CharacterSkillManager skillManager = GetComponent<CharacterSkillManager>();
            ////准备技能（判断条件）
            //SkillData data = skillManager.PrepareSkill(id);//id
            ////Debug.Log("判断条件"+data.skillID);
            ////GetComponent<Skill.CharacterSkillManager>().PrepareSkill(1002);
            //if (data != null)//生成条件
            //{
            //    //Debug.Log("生成条件" + data.prefabName);
            //    skillManager.GenerateSkill(data);

            //}
            skillSystem.AttackUseSkill(id);
        }

        private void OnJoystickMoveStart()
        {
            //GetComponent<Animator>().SetBool("run", true);
            //GetComponent<PlayerStatus>().chParams.run;
            anim.SetBool(status.chParams.run, true);
        }

        private void OnJoystickMoveEnd()
        {
            //GetComponent<PlayerStatus>().chParams.run;
            //GetComponent<Animator>().SetBool("run", true);
            anim.SetBool(status.chParams.run, false);
        }     

        private void OnJoystickMove(Vector2 dir)
        {
            //调用马达移动功能
            //dir.x     左右    0      //dir.y     上下
            //x                 y               z
            chMotor.Movement(new Vector3(dir.x,0,dir.y));



        }

        private void OnDisable()
        {
            //注销事件
            joystick.onMove.RemoveListener(OnJoystickMove);
            joystick.onMoveEnd.RemoveListener(OnJoystickMoveStart);
            joystick.onMoveEnd.RemoveListener(OnJoystickMoveEnd);
            for (int i = 0; i < skillButtons.Length; i++)
            {
                 if (skillButtons[i] == null) continue;
                if (skillButtons[i].name == "BaseButton")
                    skillButtons[i].onPressed.RemoveListener(OnSkillButtonPressed);
                else
                    skillButtons[i].onDown.RemoveListener(OnSkillButtonDown);
            }
        }
    }
}
