using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 技能释放器
    /// </summary>
    public abstract class SkillDeployer : MonoBehaviour
    {
        //由技能管理器提供
        private SkillData skillData;
        public SkillData SkillData
        {
            get
            {
                return skillData;
            }
            set
            {
                skillData = value;
                //创建算法对象
                InitDeplopyer();
            }
        }

        //选区算法对象
        private IAttackSelector selector;
        //影响算法对象
        private IImpactEffect[] impactArray;

  
        //创建算法对象
        private void InitDeplopyer()
        {
            //创建算法对象
            //选区
            selector = DeployerConfigFactory.CreateAttackSelector(skillData);
            //影响
            impactArray = DeployerConfigFactory.CreateImpactEffects(skillData);
            //技能释放器
        }


        //执行算法对象
        //选区
        public void CalculateTargets()
        {
            Debug.Log(skillData.skillID);
            Debug.Log(transform.position);
            
            skillData.attackTargets = selector.SelectTargets(skillData,transform);
            //*********测试**************
            foreach (var item in skillData.attackTargets)
            {
                print(item);
            }
        }

        //影响
        public void ImpactTargets()
        {
            for (int i = 0; i < impactArray.Length; i++)
            {
                //impactArray[i].接口方法（）;
                impactArray[i].Execute(this);
            }
        }
        //释放方式
        public abstract void DeploySkill();
    }
}
	

