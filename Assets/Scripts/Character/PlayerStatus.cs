using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPGDemo.Character//命名空间（一般格式 域名.项目名.模块）
{
   
    public class PlayerStatus :CharacterStatus
  {
        //隐藏方法 通过子类型引用调用 覆盖父类型同名方法 好像它不存在
        //在Unity中，将子类附加到物体中，创建子类对象，相当于通过子类型应用调用脚本生命周期
        //解决脚本生命周期冲突： 方法隐藏 在方法体内部通过base 关键字调用父类

        private new void Start()
        {
            //先进入子方法 在调用父类方法
            print("子类Start方法");
            base.Start();
            
        }
        //运行时修改父类方法表地址
        //因为需要调用父类，执行子类
        public override void Death()
        {
            base.Death();
            print("游戏结束");
        }

    }
}
