using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using ARPGDemo.Character;

namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    public class SectorAttackSelector : IAttackSelector
    {
        public Transform[] SelectTargets(SkillData data, Transform skillTF)
        {
            Debug.Log("选择目标");
            //根据技能数据中的标签 获取所有目标
            //data.attackTargets
            //string[] --> Transform[]
            List<Transform> targets = new List<Transform>();
            for (int i = 0; i <data.attackTargets.Length; i++)
            {
                GameObject[] tempGOArray = GameObject.FindGameObjectsWithTag("Enemy");
                //Debug.Log("游戏对象"+tempGOArray[i]);
                //GameObject[]---> Transform[]
                targets.AddRange(tempGOArray.Select(g => g.transform));
            }
            //判断攻击范围（扇形/圆形）
            targets.FindAll(t =>
            Vector3.Distance(t.position, skillTF.position) <= data.attackDistance &&
            Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
            );

            //筛选出活的角色
            targets = targets.FindAll(t => t.GetComponent<CharacterStatus>().HP > 0);
            //返回目标（单攻/群攻）
            //data.attackType
            Transform[] result = targets.ToArray();
            if (data.attackType == SkillAttackType.Group || result.Length == 0)
            {
                return targets.ToArray();
            }
            //距离最近（小）的敌人
            Transform min = result.GetMin(t => Vector3.Distance(t.position, skillTF.position));
            return new Transform[] { min };
        }
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            //1. 根据技能数据中的标签 获取所有目标
            //data.attackTargetTags
            //string[]    -->  Transform[] 
            List<Transform> targets = new List<Transform>();
            for (int i = 0; i < data.attackTargetTags.Length; i++)
            {
                GameObject[] tempGOArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
                // GameObject[]   --->   Transform[]
                targets.AddRange(tempGOArray.Select(g => g.transform));
            }

            //判断攻击范围(扇形/圆形)
            targets = targets.FindAll(t =>
                Vector3.Distance(t.position, skillTF.position) <= data.attackDistance &&
                Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
            );

            //筛选出活的角色 
            targets = targets.FindAll(t => t.GetComponent<CharacterStatus>().HP > 0);

            //返回目标(单攻/群攻)
            //data.attackType
            Transform[] result = targets.ToArray();
            if (data.attackType == SkillAttackType.Group || result.Length == 0)
                return result;
            //距离最近(小)的敌人
            Transform min = result.GetMin(t => Vector3.Distance(t.position, skillTF.position));
            return new Transform[] { min };
        }
    }
}



