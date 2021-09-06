using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARPGDemo.Character;
namespace ARPGDemo.Skill//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 伤害生命
    /// </summary>
    public class DamageImpact : IImpactEffect
    {
        private SkillData data;
        public void Execute(SkillDeployer deployer)
        {
            //deployer.SkillData.attackTargets-->CharacterStatus HP
            data = deployer.SkillData;

            deployer.StartCoroutine(RepeatDamage(deployer));
        }

        //重复伤害
        private IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            float atkTime = 0;
            do
            {
                //伤害目标生命
                OnceDamage();
                yield return new WaitForSeconds(data.atkInterval);
                atkTime += data.atkInterval;
                deployer.CalculateTargets();//重新计算目标
            } while (atkTime<data.durationTime);//攻击时间没到
           
        }
        //单次伤害
        private void OnceDamage()
        {
            //deployer.SkillData.attackTargets-->CharacterStatus HP
            //技能攻击力：攻击比率*基础攻击力
            float atk = data.atkRatio * data.owner.GetComponent<CharacterStatus>().baseATK;
            for (int i = 0; i <data.attackTargets.Length; i++)
            {
                var status = data.attackTargets[i].GetComponent<CharacterStatus>();
                status.Damage(atk);
            }
        }
    }
}
	

