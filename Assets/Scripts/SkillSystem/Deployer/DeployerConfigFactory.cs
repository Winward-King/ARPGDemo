using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Skill
{
    /// <summary>
    /// 释放器配置工厂:提供创建释放器各种算法对象的功能。
    /// 作用：将对象的创建 与 使用分离。
    /// </summary>
    public class DeployerConfigFactory
    {
        private static Dictionary<string, object> cache;

        static DeployerConfigFactory()
        {
            cache = new Dictionary<string, object>();
        }

        public static IAttackSelector CreateAttackSelector(SkillData data)
        {
            //skillData.selectorType
            //选取对象命名规则：
            //ARPGDemo.Skill.+ 枚举名+AttackSelector
            //例如扇形选区：ARPGDemo.Skill.SectorAttackSelector 
            string className = string.Format("ARPGDemo.Skill.{0}AttackSelector", data.selectorType);
            return CreateObject<IAttackSelector>(className);
        }

        public static IImpactEffect[] CreateImpactEffects(SkillData data)
        {
            IImpactEffect[] impacts = new IImpactEffect[data.impactType.Length];
            //影响效果命名规范：
            //ARPGDemo.Skill.+impactType[?]+Impact
            //例如消耗法力：ARPGDemo.Skill.CostSPImpact
            for (int i = 0; i < data.impactType.Length; i++)
            {
                string classNameImpact = string.Format("ARPGDemo.Skill.{0}Impact", data.impactType[i]);
                impacts[i] = CreateObject<IImpactEffect>(classNameImpact);
            }
            return impacts;
        }

        private static T CreateObject<T>(string className) where T : class
        {
            if (!cache.ContainsKey(className))
            {
                Debug.Log("反射");
                Type type = Type.GetType(className);
                object instance = Activator.CreateInstance(type);
                cache.Add(className, instance);
            }
            return cache[className] as T;
        }
    }
}