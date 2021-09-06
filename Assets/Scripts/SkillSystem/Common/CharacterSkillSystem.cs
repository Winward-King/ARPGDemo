using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;


namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    [RequireComponent(typeof(CharacterSkillManager))]
    /// <summary>
    /// 封装技能系统，提供简单的技能释放功能
    /// </summary>
    public class CharacterSkillSystem : MonoBehaviour
    {
        private CharacterSkillManager skillManager;
        private Animator anim;

        private void Start()
        {
            skillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
            GetComponentInChildren<AnimationEventBehaviour>().AttackHandler += DeploySkill;
        }

        private void DeploySkill()
        {
            //生成技能
            skillManager.GenerateSkill(skill);
        }
        private SkillData skill;
        public void AttackUseSkill(int skillID, bool isBatter = false)
        {
            //如果连击，则从上一个释放技能中获取连击技能编号
            if(skill != null&& isBatter)
            {
                skillID = skill.nextBatterId;
            }

            //准备技能
            skill = skillManager.PrepareSkill(skillID);
            if (skill == null) return;
            //播放动画
            anim.SetBool(skill.animationName, true);
            //生成技能
            //如果单攻
            //查找目标
            Transform targetTF = SelectTaraget();
            //--朝向技能
            transform.LookAt(targetTF);
            //--选中目标
            //transform.LookAt()
            //--选中目标
            // 1. 选中目标，间隔指定时间后取消选中。
            // 2. 选中A目标，在自动取消前，又选中B目标，则需要手动将A取消
            //  （核心思想：存储上次选中的物体）
            //先取消上次选中物体
            SetSelectedActiveFx(false);
            selectedTarget = targetTF;
            //选中当前物体
            SetSelectedActiveFx(true);
        }

        //选中目标
        private Transform selectedTarget;
        private Transform SelectTaraget()
        {
            Transform[] target = new SectorAttackSelector().SelectTargets(skill, transform);
            return target.Length != 0 ? target[0] : null;
        }
        private void SetSelectedActiveFx(bool state)
        {
            if (selectedTarget == null) return;
            var selected = selectedTarget.GetComponent<Character.CharacterSelected>();
            if (selected) selected.SetSelectedActive(state);//(true改为变量)
        }

        /// <summary>
        /// 使用随机技能（为Npc提供）
        /// </summary>
        public void UseRandomSkill()
        {
            //需求 从管理器中挑选出随机的技能
            //--先产生随机数 在判断技能是否可以释放
            //--先筛选出所有可以释放的技能，在产生随机数
            var usableSkills = skillManager.skills.FindAll(s => skillManager.PrepareSkill(s.skillID) != null);
            if (usableSkills.Length == 0) return;
            int index = UnityEngine.Random.Range(0, usableSkills.Length);
            AttackUseSkill(usableSkills[index].skillID);

        }
    }
}


