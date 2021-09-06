using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character//命名空间（一般格式 域名.项目名.模块）
{
    /// <summary>
    /// 角色状态类
    /// </summary>
    public class CharacterStatus : MonoBehaviour
    {
        [Tooltip("动画参数")]
        public CharacterAnimationParameter chParams;
        [Tooltip("血量")]
        public float HP;
        [Tooltip("最大血量")]
        public float maxHP;
        [Tooltip("法力")]
        public float SP;
        [Tooltip("最大法力")]
        public float maxSP;
        [Tooltip("基础攻击力")]
        public float baseATK;
        [Tooltip("防御力")]
        public float defence;
        [Tooltip("攻击间隔")]
        public float attackInterval;
        [Tooltip("攻击距离")]
        public float attackDistance;

        protected void Start()
        {
            //print("父类Start方法");
        }

        public void Damage(float val)//10
        {
            //val -= defencee;//10 - 20
            if (val <= 0) return;
            HP -= val;//100--10
            if (HP <= 0) Death();
        }
        //调用父类 死亡方法 执行子类死亡方法（多态）
        public virtual void Death()
        {
            GetComponentInChildren<Animator>().SetBool(chParams.death, true);
            print("游戏结束");
        }
    }
}
