using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 影响算法接口
    /// </summary>
    public interface IImpactEffect 
    {
        //伤害 生命值 持续时间
        //void Execute(SkillData data);
        //需要给脚本 不是数据
        void Execute(SkillDeployer deployer);
    }
}
	

