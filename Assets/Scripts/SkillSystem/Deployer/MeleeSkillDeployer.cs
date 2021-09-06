using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
namespace ARPGDemo.Skill
{
    public class MeleeSkillDeployer : SkillDeployer
    {
        /// <summary>
        /// 近身释放器
        /// </summary>
        public override void DeploySkill()
        {
            Debug.Log("执行选区算法");
            //执行选区算法
            CalculateTargets();
            //执行影响算法
            ImpactTargets();

        }

    }
}
