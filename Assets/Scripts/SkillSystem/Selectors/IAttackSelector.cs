using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 攻击选区的接口
    /// </summary>
    public interface IAttackSelector
    {
        /// <summary>
        /// 搜索目标
        /// </summary>
        /// <param name="data">技能数据</param>
        /// <param name="skillTF">技能所在物体的变换组件</param>
        /// <returns></returns>
        Transform[] SelectTargets(SkillData data, Transform skillTF);

    }
}


