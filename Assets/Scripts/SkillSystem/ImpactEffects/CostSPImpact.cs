using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPGDemo.Character;
namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    public class CostSPImpact : IImpactEffect
    {
        //依赖注入 控制反转
        public void Execute(SkillDeployer deployer)
        {
            var status = deployer.SkillData.owner.GetComponent<CharacterStatus>();
            status.SP -= deployer.SkillData.costSP;
        }

       
    }
}
	

